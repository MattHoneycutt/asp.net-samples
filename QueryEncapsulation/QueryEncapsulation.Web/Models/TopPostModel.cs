using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Heroic.AutoMapper;
using QueryEncapsulation.Web.Domain;

namespace QueryEncapsulation.Web.Models
{
	public class TopPostModel : IMapFrom<Post>, IHaveCustomMappings
	{
		public string Title { get; set; }

		public DateTime PostDate { get; set; }

		public int CommentCount { get; set; }

		public IList<string> MicrosoftPosterAddresses { get; set; }
		
		public void CreateMappings(IConfiguration configuration)
		{
			configuration.CreateMap<Post, TopPostModel>()
				.ForMember(x => x.CommentCount, opt => opt.MapFrom(x => x.Comments.Count()))
				.ForMember(x => x.MicrosoftPosterAddresses, opt => MapFromMicrosoftPosters(opt));
		}

		private void MapFromMicrosoftPosters(IMemberConfigurationExpression<Post> opt)
		{
			opt.MapFrom(x => x.Comments.Where(c => c.Email.Contains("@microsoft.com")).Select(c => c.Email));
		}
	}
}