using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Controllers;
using MusicStore.WebUI.Models;

namespace MusicStore.UnitTests
{
	[TestClass]
	public class SendPaginationViewModelUnitTest
	{
		[TestMethod]
		public void CanSendPaginationViewTest()
		{
			var mock = new Mock<IMusicRepository>();
			mock.Setup(m => m.MusicTracks).Returns(new List<MusicTrack>
			{
				new MusicTrack {MusicTrackId = 1, Name = "Track1"},
				new MusicTrack {MusicTrackId = 2, Name = "Track2"},
				new MusicTrack {MusicTrackId = 3, Name = "Track3"},
				new MusicTrack {MusicTrackId = 4, Name = "Track4"},
				new MusicTrack {MusicTrackId = 5, Name = "Track5"},
			});
			var controller = new MusicController(mock.Object) {pageSize = 3};

			var result = (MusicListViewModel) controller.List(2).Model;

			var pagingInfo = result.pagingInfo;
			Assert.AreEqual(pagingInfo.CurrentPage, 2);
			Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
			Assert.AreEqual(pagingInfo.TotalItems, 5);
			Assert.AreEqual(pagingInfo.TotalPages, 2);
		}
	}
}
