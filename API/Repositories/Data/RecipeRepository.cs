﻿using API.Context;
using API.Handler;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;

namespace API.Repositories.Data;

public class RecipeRepository : GeneralRepository<Recipe, int, MyContext>, IRecipeRepository
{
    public RecipeRepository(MyContext context) : base(context)
    {
    }

    public int Recipe(RecipeVM recipeVM)
    {
        int result = 0;
        // Insert to Recipe Table
        var recipe = new Recipe
        {
            Id = recipeVM.Id,
            RecipeName = recipeVM.RecipeName,
            Description = recipeVM.Description,
            Step = recipeVM.Step,
            CookingTime = recipeVM.CookingTime,
            Difficulty = recipeVM.Difficulty
        };
        _context.Set<Recipe>().Add(recipe);
        result += _context.SaveChanges();

        // Insert to Request Table
        var request = new Request
        {
            RecipeId = recipeVM.Id,
            RecipeName = recipeVM.RecipeName,
            IsApproved = false
        };
        _context.Set<Request>().Add(request);
        result += _context.SaveChanges();

        return result;
    }
}