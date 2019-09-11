using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transitions.Models;

namespace Transitions.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description.",Imagem="https://www.medicalnewstoday.com/content//images/articles/322/322868/golden-retriever-puppy.jpg" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description.",Imagem="https://www.nationalgeographic.com/content/dam/animals/thumbs/rights-exempt/mammals/d/domestic-dog_thumb.jpg" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." ,Imagem="https://www.petmd.com/sites/default/files/Acute-Dog-Diarrhea-47066074.jpg"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description.",Imagem="https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/gettyimages-1094874726.png" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." ,Imagem="https://pixel.nymag.com/imgs/fashion/daily/2019/06/18/18-puppy-dog-eyes.w700.h700.jpg"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.",Imagem="https://cdn.psychologytoday.com/sites/default/files/styles/article-inline-half/public/field_blog_entry_images/2018-02/vicious_dog_0.png" }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}