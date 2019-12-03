using System;
using System.Collections.Generic;
using System.Text;

namespace Iceland_shopkeeper.Dependency
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
