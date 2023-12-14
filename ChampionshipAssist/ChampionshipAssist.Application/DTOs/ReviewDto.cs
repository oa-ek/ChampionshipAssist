using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipAssist.Application.DTOs
{
	public class ReviewDto
	{
		public string Id { get; set; }
		public string ReviewId { get; set; }
		public string UserId { get; set; }
		public string Commentary { get; set; }
		public string Rating { get; set; }
	}
}
