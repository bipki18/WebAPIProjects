﻿using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.Component.CategoryComponent
{
    public interface ICategoryComponent
    {
        Task<Category> GetAllcategory();

    }
}
