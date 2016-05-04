using System;
using System.Collections.Generic;
using System.Text;

namespace Globals
{
    public enum OperMode
    {
        Find=0, 
        New=1, 
        Add=2, 
        Changing=3, 
        Changed=4, 
        ChangeCancel=5, 
        Delete=6,
        View=7
    }

    public struct ItemTextVal
    {
        private string _DispMem, _ValMem;
        public ItemTextVal(string DisMem, string ValMem)
        {
            this._DispMem = DisMem;
            this._ValMem = ValMem;
        }

        public string DispMember { get { return _DispMem; } }
        public string ValMember { get { return _ValMem; } }
    }

    class regUserInfo
    {
        private static int _emp_id = 0;
        private static string _name = "";
        private static string _sname = "";
        public int EmpID
        {
            get { return _emp_id; }
            set { _emp_id = value; }
        }
        public string EmpName
        {
            get { return _name; }
            set { _name = value; }

        }
        public string EmpSName
        {
            get { return _sname; }
            set { _sname = value; }

        }
    }

    class loginUserInfo
    {
        private static int _emp_id = 0;
        private static string _name = "";
        private static string _sname = "";
        private static string _extra_field = "";

        public int EmpID
        {
            get { return _emp_id; }
            set { _emp_id = value; }
        }
        public string EmpName
        {
            get { return _name; }
            set { _name = value; }
        }
        public string EmpSName
        {
            get { return _sname; }
            set { _sname = value; }
        }
        public string extra_field
        {
            get { return _extra_field; }
            set { _extra_field = value; }
        }
    }
    class SelStudInfo
    {
        private static string _stud_id = "";
        private static string _name = "";
        private static string _sname = "";
        private static string _dep = "";
        private static string _fac = "";

        private static string _eduLevel = "";
        private static string _dep_id = "";
        private static string _eyear = "";
        private static string _year = "";
        private static string _danisman = "";
        private static Int16 _kurs = 0;

        public string StudID
        {
            get { return _stud_id; }
            set { _stud_id = value; }
        }
        public string year
        {
            get { return _year; }
            set { _year = value; }
        }
        public string edu_year
        {
            get { return _eyear; }
            set { _eyear = value; }
        }
        public string SName
        {
            get { return _name; }
            set { _name = value; }

        }
        public string SSName
        {
            get { return _sname; }
            set { _sname = value; }
        }
        public Int16 Kurs
        {
            get { return _kurs; }
            set { _kurs = value; }
        }
        public string Dep
        {
            get { return _dep; }
            set { _dep = value; }
        }
        public string DepID
        {
            get { return _dep_id; }
            set { _dep_id = value; }
        }
        public string Fac
        {
            get { return _fac; }
            set { _fac = value; }
        }
        
        public string Danisman
        {
            get { return _danisman; }
            set { _danisman = value; }
        }

        public string eduLevel
        {
            get { return _eduLevel; }
            set { _eduLevel = value; }
        }

        public bool isSelectStud()
        {
            if (_stud_id.Length != 9)
            {
                System.Windows.Forms.MessageBox.Show("No Student was selected..! Please, select a student first.", "MISSING DATA", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }
    }
    class GenFunc
    {
        public GenFunc() { }
        public void LoadImg(ref System.Windows.Forms.PictureBox Img, byte[] b)
        {
            if (b.Length > 0)
            {
                // Open a stream for the image and write the bytes into it
                System.IO.MemoryStream stream = new System.IO.MemoryStream(b, true);
                stream.Write(b, 0, b.Length);
                // Create a bitmap from the stream
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(stream);
                // Check for scaling and assign the bitmap to the Picturebox
                if (bmp.Width > 500 && bmp.Height > 300)
                {
                    System.Drawing.Bitmap bmp1 = new System.Drawing.Bitmap(bmp, new System.Drawing.Size(500, 300));
                    Img.Image = bmp1;
                }
                else
                    Img.Image = bmp;
                // Close the stream
                stream.Close();
            }
        }
    }

}
