﻿using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int writerID);
        List<Content> GetListByHeadingID(int headingID);
        void ContentAdd(Content content);
        Content GetByID(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);

    }
}
