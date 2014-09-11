using FirstFloor.ModernUI.Windows;
using Microsoft.Practices.Prism.Modularity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modulization.Content
{
    public class ContentCatalog : IContentCatalog
    {
        #region Deklaration

        List<IContent> mInternalList = new List<IContent>();



        #endregion

        #region Properties

        public IContent this[int index]
        {
            get { return mInternalList[index]; }
            set { mInternalList.Insert(index, value); }
        }

        #endregion

        #region Konstruktor

        public ContentCatalog(CompositionContainer container)
        {
            var content = container.GetExportedValues<IContent>();
            if (content != null)
            {
                mInternalList.AddRange(content);
            }
            
        }


        #endregion

        #region Events



        #endregion

        #region Diverses

        #endregion



        #region IEnumerable<IContent> Member

        public IEnumerator<IContent> GetEnumerator()
        {
            return mInternalList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Member

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
