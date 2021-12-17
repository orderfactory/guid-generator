using System;
using System.Collections.Generic;
using SortableGUID = System.Data.SqlTypes.SqlGuid;
using Xunit;

namespace OrderFactory.GuidGenerator.Tests
{
    public class GuidGeneratorTests
    {
        [Fact]
        public void TestIsUnique()
        {
            var guidGenerator = new GuidGenerator();
            Guid ga = guidGenerator.NewGuid();
            Guid gb = guidGenerator.NewGuid();
            Assert.NotEqual(ga, gb);
        }

        [Fact]
        public void TestSortOrder()
        {
            var guidGenerator = new GuidGenerator();
            const int COUNT = 32; //Max safe value for testing without Sleep below is (0xFFFF-0x0FFF-1)
            Guid[] guids = new Guid[COUNT];

            var sortableGuids = new List<SortableGUID>();

            for (int i = 0; i < COUNT; i++)
            {
                guids[i] = guidGenerator.NewGuid();
                sortableGuids.Add(new SortableGUID(guids[i]));
                //see the max safe value note above
                //Thread.Sleep(1); //need to sleep for a millisecond, otherwise the timestamp may not update
            }
            sortableGuids.Sort();

            for (int i = 0; i < COUNT; i++)
            {
                Assert.Equal(guids[i], sortableGuids[i]);
            }

        }
    }
}
