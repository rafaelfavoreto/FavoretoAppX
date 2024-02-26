using FavoretoAppX.Domain.Core;
using FavoretoAppX.Domain.Enum;
using FavoretoAppX.Domain.Resources;
using FavoretoAppX.Domain.Validations;
using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FavoretoAppX.Domain.Models;

public class Product : Entity
{
    //In the class characterized by a rich domain concept,
    //we define behaviors within the class rather than
    //just simple getters and setters.

    public Product(string name, decimal price, ProductStatusEnum status, string sku, int stock)
    {
        Name = name;
        Price = price;
        Status = status;
        Sku = sku;
        Stock = stock;
    }

    [Required(ErrorMessage = "Product name is required.")]
    public string Name { get; private set; }
    [Range(0, double.MaxValue, ErrorMessage = "The product price must be greater than zero.")]
    public decimal Price { get; private set; }
    [Required(ErrorMessage = "Product SKU is required.")]
    public string Sku { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Product stock must be greater than or equal to zero.")]
    public int Stock { get; set; }
    [Required(ErrorMessage = "Product status is required.")]
    public ProductStatusEnum Status { get; private set; }
    [Required(ErrorMessage = "Product Date is required.")]
    public DateTime CreatedDate { get; private set; } = DateTime.Now;

    [JsonIgnore]
    public string StatusDescription => Status.GetDescription();

    private readonly ProductValidator _validator = new();

    #region Aux. Methos

    public decimal Calculator()
    {
        return Price * Stock;
    }

    #endregion

    public void Validate()
    {
        _validator.ValidateAndThrow(this);
    }
}