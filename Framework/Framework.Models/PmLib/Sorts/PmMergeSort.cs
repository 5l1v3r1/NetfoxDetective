/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2012-2013 Brno University of Technology - Faculty of Information Technology (http://www.fit.vutbr.cz)
 * Author(s):
 * Vladimir Vesely (mailto:ivesely@fit.vutbr.cz)
 * Martin Mares (mailto:xmares04@stud.fit.vutbr.cz)
 * Jan Plusal (mailto:xplusk03@stud.fit.vutbr.cz)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
 * documentation files (the "Software"), to deal in the Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
 * and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
 * TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
 * TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using System;
using System.Collections.Generic;
using Netfox.Framework.Models.PmLib.Frames;

namespace Netfox.Framework.Models.PmLib.Sorts
{
    /// <summary>
    ///     Inplace unstable sorting algorithm
    /// </summary>
    internal class PmMergeSort
    {
        public static void Merge(IList<PmFrameBase> list, Int32 offset, Int32 sizei, Int32 sizej)
        {
            PmFrameBase temp;
            var ii = 0;
            var ji = sizei;
            var flength = sizei + sizej;

            for(var f = 0; f < (flength - 1); f++)
            {
                if(sizei == 0 || sizej == 0) { break; }

                if(list[offset + ii].CompareTo(list[offset + ji]) < 0)
                {
                    ii++;
                    sizei--;
                }
                else
                {
                    temp = list[offset + ji];

                    for(var z = (ji - 1); z >= ii; z--) { list[offset + z + 1] = list[offset + z]; }
                    ii++;

                    list[offset + f] = temp;

                    ji++;
                    sizej--;
                }
            }
        }

        public static List<PmFrameBase> MergeSort(List<PmFrameBase> list, Int32 offset = 0, Int32 len = -1)
        {
            if(list == null) { return null; }

            if(len == -1) { len = list.Count; }

            Int32 listsize;

            for(listsize = 1; listsize <= len; listsize *= 2) {
                for(Int32 i = 0, j = listsize; (j + listsize) <= len; i += (listsize*2), j += (listsize*2)) { Merge(list, i, listsize, listsize); }
            }

            listsize /= 2;

            var xsize = len%listsize;
            if(xsize > 1) { MergeSort(list, len - xsize, xsize); }

            Merge(list, 0, listsize, xsize);

            return list;
        }
    }
}