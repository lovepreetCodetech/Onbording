﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Onbording.Models
{
   public class store
	{
			
     public int Id { set; get; }
	 [Required]
	 public string Name { set; get; }
	 [Required]
	 public string Address { set; get; }


	 public ICollection<sales> Sales { set; get; }
		}
	
}