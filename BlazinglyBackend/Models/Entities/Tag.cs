﻿using System;
using System.Collections.Generic;

namespace APIBackend.Models.Entities;

public partial class Tag
{
    public int Id { get; set; }

    public string TagName { get; set; }

    public int TagItemId { get; set; }
}
