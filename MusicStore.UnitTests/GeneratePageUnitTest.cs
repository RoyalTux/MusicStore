using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.WebUI.HtmlHelpers;
using MusicStore.WebUI.Models;

namespace MusicStore.UnitTests
{
	[TestClass]
	public class GeneratePageUnitTest
	{
		[TestMethod]
		public void CanGeneratePageLinksTest()
		{
			var pagingInfo = new PagingInfo
			{
				CurrentPage = 2,
				TotalItems = 28,
				ItemsPerPage = 10
			};

			string PageUrlDelegate(int i) => "Page" + i;

			var result = ((HtmlHelper) null).PageLinks(pagingInfo, PageUrlDelegate);

			Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
			                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
			                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
				result.ToString());
		}
	}
}
