﻿using Core.Entities;

namespace Core.Specifications;
public class ProductSpecification : BaseSpecification<Product> {
    public ProductSpecification (string? brand, string? type, string? sort) : base(x =>
    (string.IsNullOrWhiteSpace(brand) || x.Brand == brand) &&
    (string.IsNullOrWhiteSpace(type) || x.Type == type)
    ) {
        Console.WriteLine("-------------------------------");
        Console.WriteLine(sort);
        switch (sort) {
        case "priceAsc":
            AddOrderBy(x => x.Price);
            break;
        case "priceDesc":
            AddOrderByDescending(x => x.Price);
            break;
        default:
            AddOrderBy(x => x.Name);
            break;
        }
    }
}

