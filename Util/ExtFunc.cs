using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public static class ExtFunc
    {
        public static int Indexof(this byte[] bArr, byte[] bArr1,int startPosition)
        {
            for (int i = startPosition; i < bArr.Length; i++)
            {
                if (bArr[i] == bArr1[0])
                {
                    int j = 1;
                    while (j < bArr1.Length)
                    {
                        if (bArr1[j] != bArr[i + j])
                            break;
                        j++;
                    }
                    if (j == bArr1.Length) return i;
                }
            }
            return -1;
        }

        public static int Indexof(this byte[] bArr, byte[] bArr1)
        {
            return Indexof(bArr, bArr1, 0);
        }
    }
}
