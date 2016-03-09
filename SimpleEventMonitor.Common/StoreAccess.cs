﻿using System;

namespace SimpleEventMonitor.Common
{
    public class StoreAccess
    {
        private readonly Func<IEventDataStore> _dataStoreGetter;

        public StoreAccess(Func<IEventDataStore> dataStoreGetter)
        {
            _dataStoreGetter = dataStoreGetter;
        }

        public IEventDataStore Current => _dataStoreGetter();
    }
}