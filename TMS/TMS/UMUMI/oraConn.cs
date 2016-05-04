using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using Oracle.DataAccess.Types;

namespace DB
{
    class oraConn
    {

        //OFFLINE DATABASE
        private const string connectionString_ = "Data Source=(DESCRIPTION="
                                  + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.5.26)(PORT=1521)))"
                                  + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ntnudb)));" //
                                  + "User Id=studinfoman;Password=asd12345;";

      /*  private const string connectionString_ = "Data Source=(DESCRIPTION="
                                + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.5.26)(PORT=1521)))"
                                + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ntnudb)));" //
                                + "User Id=studinfoman;Password=asd12345;";*/


        private OracleConnection _conn;

        static private oraConn _dB = null;

        static public oraConn DB
        {
            get
            {
                if (_dB == null) _dB = new oraConn();
                return _dB;
            }
        }

        public OracleConnection conn
        {
            get { return _conn; }
        }

        public bool IsConAlive() 
        {
            OracleCommand cmd = null;
            OracleDataReader odr = null;
            try
            {
                cmd = new OracleCommand("select 1 from dual", this.conn);
                odr = cmd.ExecuteReader(CommandBehavior.KeyInfo);
            }
            catch (Exception) { return false; }
            finally
            {
                if(odr != null) odr.Close();
                if (odr != null) odr.Dispose();
                if (cmd != null) cmd.Dispose();
            }
            return true;
        }

        public oraConn()
        {
            start:
            try
            {                
                _conn = new OracleConnection(connectionString_);
                _conn.Open();                       
            }
            catch (Exception e) 
            {
                if (System.Windows.Forms.MessageBox.Show("Coludn't connect to database : " + e.Message.ToString(), "Connection ERROR", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Retry)
                {
                    goto start;
                    
                }
            }
        }

        public bool RepairConn() 
        {
            if (this.IsConAlive()) return true;
            try
            {
                this._conn = new OracleConnection(connectionString_);
                this._conn.Open();
            }
            catch
            {
                this.IsConAlive();
            }
            return this.IsConAlive();            
        }

        public void CloseConn()
        {
            this._conn.Close();
        }

        public OracleDataReader execSQL(string aSql)
        {
            OracleCommand cmd = GetCommand(aSql);
            try
            {
                return cmd.ExecuteReader(CommandBehavior.KeyInfo);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }

        public OracleDataReader execSQL(string aSql, OracleParameter[] prms)
        {
            OracleCommand cmd = GetCommand(aSql, prms);
            try
            {
                return cmd.ExecuteReader(CommandBehavior.KeyInfo);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }

        public OracleDataReader execSQL(string aSql, List<OracleParameter> prms)
        {
            return execSQL(aSql, prms.ToArray());
        }

        public OracleParameter SetParameter(string sParamName, OracleDbType DbType, Int32 iSize, ParameterDirection sDirection, object oParamValue)
        {
            OracleParameter param;
            if (iSize == -1) param = new OracleParameter(sParamName, DbType);
            else param = new OracleParameter(sParamName, DbType, iSize);
            param.Direction = sDirection;
            param.Value = oParamValue;
            return param;
        }

        public OracleCommand GetCommand(string sqlString)
        {
            OracleCommand cmd = new OracleCommand(sqlString, conn);
            cmd.BindByName = true;
            return cmd;
        }

        public OracleCommand GetCommand(string sqlString, OracleParameter[] prms)
        {
            OracleCommand cmd = new OracleCommand(sqlString, conn); cmd.BindByName = true;
            if (prms != null)
            {
                foreach (OracleParameter parameter in prms) cmd.Parameters.Add(parameter);
            }
            return cmd;
        }

        public object ExecSProcRetVal(string sProcName, OracleParameter[] prms, string sRetValParam)
        {
            OracleCommand cmd = GetCommand(sProcName, prms);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteScalar();
            return cmd.Parameters[sRetValParam].Value;
        }

        public void ExecSProcRetVal(string sProcName, OracleParameter[] prms)
        {
            OracleCommand cmd = GetCommand(sProcName, prms);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteScalar();
        }

        public object ExecSqlRetVal(string sProcName, OracleParameter[] prms)
        {
            OracleCommand cmd = GetCommand(sProcName, prms);
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteScalar();
        }

        public DataTable GetDataTable(string sqlString) 
        {
            OracleCommand cmd = GetCommand(sqlString);
            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            adp.Fill(dtbl);
            return dtbl;
        }
        
        public DataTable GetDataTable(string sqlString, OracleParameter[] prms)
        {
            OracleCommand cmd = GetCommand(sqlString, prms);
            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            adp.Fill(dtbl);
            return dtbl;
        }

        public DataTable GetDataTable(string sqlString, List<OracleParameter> prms)
        {
            return GetDataTable(sqlString, prms.ToArray());
        }

        public DataSet GetDataSet(string sProcName, OracleParameter[] prms)
        {
            DataSet ds = new DataSet(); 
            try
            {
                OracleCommand objCmd = GetCommand(sProcName, prms);
                OracleDataAdapter myAdptr = new OracleDataAdapter();
                myAdptr.SelectCommand = objCmd;
                myAdptr.Fill(ds, "myTable");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public System.Drawing.Image GetImageBySql(string sql)
        {
            OracleDataReader odr = execSQL(sql);
            odr.Read();
            try
            {
                OracleBlob blob = odr.GetOracleBlob(0); odr.Close();
                Byte[] byteArr = new Byte[blob.Length];
                int i = blob.Read(byteArr, 0, System.Convert.ToInt32(blob.Length));
                System.IO.MemoryStream memStream = new System.IO.MemoryStream(byteArr);
                return System.Drawing.Image.FromStream(memStream);
            }
            catch { return null; }
        }

        public void load_ComboBox(System.Windows.Forms.ComboBox cmb, string sql, string DspMem, string ValMem)
        {
            try
            {
                cmb.DataSource = GetDataTable(sql);
                cmb.DisplayMember = DspMem;
                cmb.ValueMember = ValMem;
            }
            catch (Exception) { }
        }

        public void load_lookUp(DevExpress.XtraEditors.LookUpEdit lookUp, string str_SQL, string Display, string Value)
        {
            try
            {
                DataTable dt = new DataTable(); dt = GetDataTable(str_SQL);
                lookUp.Properties.ValueMember = Value;
                lookUp.Properties.DisplayMember = Display;
                lookUp.Properties.DataSource = dt;                
                lookUp.Properties.DropDownRows = (dt.Rows.Count > 10) ? 10 : dt.Rows.Count; 
            }
            catch (Exception) { }
        }

        public void load_checkedCombo(DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo, string str_SQL, string Display, string Value)
        {
            try
            {
                DataTable dt = new DataTable(); dt = GetDataTable(str_SQL);
                checkedCombo.Properties.ValueMember = Value;
                checkedCombo.Properties.DisplayMember = Display;
                checkedCombo.Properties.DataSource = dt;                
                if (dt.Rows.Count < 10) checkedCombo.Properties.DropDownRows = dt.Rows.Count;
            }
            catch (Exception) { }
        }
    }
}
