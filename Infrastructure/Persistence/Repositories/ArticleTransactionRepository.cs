﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ArticleTransactionRepository(DataBaseContext context) : RepositoryBase<ArticleTransaction>(context), IArticleTransactionRepository
    {

    }
}
