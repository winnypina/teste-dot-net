using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web.Models;

namespace Web.ViewModels
{
    public class ItemFormViewModel
    {
        public Item Item { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public DateTime Data { get; set; }
        public List<Models.Item> items { get; set; }

        public ItemFormViewModel()
        {
            Id = 0;
        }

        public ItemFormViewModel(Item item)
        {
            Id = item.Id;
            Nome = item.Nome;
            Categoria = item.Categoria;
            Data = item.Data;
        }
    }
}