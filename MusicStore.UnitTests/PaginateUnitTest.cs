using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Controllers;
using MusicStore.WebUI.Models;

namespace MusicStore.UnitTests
{
	[TestClass]
	public class PaginateUnitTest
	{
		[TestMethod]
		public void CanPaginateTest()
		{
			var mock = new Mock<IMusicRepository>();
			mock.Setup(m => m.MusicTracks).Returns(new List<MusicTrack>
			{
				new MusicTrack {MusicTrackId = 1, Name = "Track1"},
				new MusicTrack {MusicTrackId = 1, Name = "Track2"},
				new MusicTrack {MusicTrackId = 1, Name = "Track3"},
				new MusicTrack {MusicTrackId = 1, Name = "Track4"},
				new MusicTrack {MusicTrackId = 1, Name = "Track5"},
			});
			var controller = new MusicController(mock.Object) {pageSize = 3};

			//var resultTracks = (IEnumerable<MusicTrack>) controller.List(2).Model;
			var resultTracks = (MusicListViewModel)controller.List(2).Model;

			var musicTracks = resultTracks.musicTracks.ToList();
			Assert.IsTrue(musicTracks.Count == 2);
			Assert.AreEqual(musicTracks[0].Name, "Track4");
			Assert.AreEqual(musicTracks[1].Name, "Track5");
		}
	}
}
