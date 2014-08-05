﻿using Easy.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Modules.DataDictionary
{
    public class DataDictionaryService : ServiceBase<DataDictionaryEntity>, IDataDictionaryService
    {
        DataDictionaryRepository rep = new DataDictionaryRepository();
        public IEnumerable<DataDictionaryEntity> GetDictionaryByType(string dicType)
        {
            return Get(new Data.DataFilter().Where(string.Format("T0.DicValue<>'0' and T0.DicName='{0}'", dicType)));
        }
        public IEnumerable<string> GetDictionaryType()
        {
            return rep.GetDictionaryType();
        }
        public override void Add(DataDictionaryEntity item)
        {
            var parent = this.Get(item.Pid);
            item.DicName = parent.DicName;
            base.Add(item);
        }
    }
}
