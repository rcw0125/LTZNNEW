using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace LTZN.�����±�
{
    public class �����±����� : BindingList<�����±�������>
    {

        public int nian;
        public int yue;

        public �����±�����(int nian, int yue)
        {
            this.nian = nian;
            this.yue = yue;
        }

        public �����±������� Get�����±�������(string ��λ, string ��Ŀ)
        {
            �����±������� rx = null;
            foreach (�����±������� x in this)
            {
                if (x.P01��λ == ��λ && x.P02��Ŀ == ��Ŀ)
                    rx = x;
            }
            return rx;
        }
    }
}
