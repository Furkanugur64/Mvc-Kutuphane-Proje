using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcKutuphaneProje.Models.Entity;

namespace MvcKutuphaneProje.Models.Siniflarim
{
    public class Class1
    {
        public IEnumerable<TBL_KITAPLAR> Kıtap { get; set; }
        public IEnumerable<TBL_HAKKIMIZDA> Bılgı { get; set; }

    }
}