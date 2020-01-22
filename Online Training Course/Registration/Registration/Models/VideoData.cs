using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.Models
{
    public class VideoData
    {
        public ArrayList Email = new ArrayList();
        public ArrayList Topic = new ArrayList();
        public ArrayList File = new ArrayList();

        public String filter(String file)
        {
            char[] a = file.ToCharArray();
            String res = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '/' || a[i] == '\\' || a[i] == '#' || a[i] == '-' || a[i] == ','  || a[i] == '&' || a[i]==' ')
                {

                }
                else
                {
                    res += a[i];
                }
            }
            return res;
        }
    }
}