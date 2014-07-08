﻿/*
 * ******************************************************************************
 *   Copyright 2014 Spectra Logic Corporation. All Rights Reserved.
 *   Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *   this file except in compliance with the License. A copy of the License is located at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 *   or in the "license" file accompanying this file.
 *   This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *   CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *   specific language governing permissions and limitations under the License.
 * ****************************************************************************
 */

using System;

namespace Ds3.Helpers
{
    public interface ICriticalSectionExecutor
    {
        void InLock(Action action);
        T InLock<T>(Func<T> func);
    }

    public class CriticalSectionExecutor : ICriticalSectionExecutor
    {
        private readonly Object _lock = new object();

        public void InLock(Action action)
        {
            lock (this._lock)
            {
                action();
            }
        }

        public T InLock<T>(Func<T> func)
        {
            lock (this._lock)
            {
                return func();
            }
        }
    }
}
