using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Query;

namespace Ecommerce.Infrastructure.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<Category?> CreateCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        var mappedCategory = _mapper.Map<CategoryDto, Category>(categoryDto);

        if (mappedCategory is null)
        {
            Log.Error("Cant Create Map From CategoryDto to Category At CategoryService");
            return mappedCategory;
        }

        try
        {
            await _unitOfWork.Repository<Category>().AddAsync(mappedCategory, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return mappedCategory;
        }
        catch (Exception ex)
        {
            Log.Error("Error During Create Category From Category Service", ex.Message);
            return null;
        }
    }

    public async Task<IReadOnlyList<Category>?> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _unitOfWork.Repository<Category>().GetAllAsNoTrackingAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Log.Error("Error During Get All Categories From Category Service", ex.Message);
            return null;
        }
    }

    public Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var category = _unitOfWork.Repository<Category>().GetByIdAsNotTrackingAsync(id, cancellationToken);
            return category;
        }
        catch (Exception ex)
        {
            Log.Error("Error During Get Category By Id From Category Service", ex.Message);
            return Task.FromResult<Category?>(null);
        }
    }

    public async Task<CategoryToReturnDto> UpdateCategoryAsync(int id, UpdatedCategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        var existingCategory = await _unitOfWork.Repository<Category>().GetByIdAsync(id, cancellationToken);
        try
        {
            await _unitOfWork.Repository<Category>().ExecuteUpdateAsync(c => c.Id == id,
            p => p.SetProperty(c => c.ArabicName, categoryDto.ArabicName == "string" ? existingCategory!.ArabicName : categoryDto.ArabicName)
            .SetProperty(c => c.EnglishName, categoryDto.EnglishName == "string" ? existingCategory!.EnglishName : categoryDto.EnglishName)
            .SetProperty(c => c.ArabicDescription, categoryDto.ArabicDescription == "string" ? existingCategory!.ArabicDescription : categoryDto.ArabicDescription)
            .SetProperty(c => c.EnglishDescription, categoryDto.EnglishDescription == "string" ? existingCategory!.EnglishDescription : categoryDto.EnglishDescription)
            , cancellationToken);

            var mappedCategory = _mapper.Map<UpdatedCategoryDto, CategoryToReturnDto>(categoryDto);
            if (mappedCategory is null)
            {
                Log.Error("Cant Create Map From CategoryDto to CategoryToReturnDto At CategoryService");
                return null!;
            }
            mappedCategory!.Id = id;
            return mappedCategory!;
        }
        catch (Exception ex)
        {
            Log.Error("Error During Update Category By Id From Category Service", ex.Message);
            return null!;
        }
    }
    public async Task<bool> DeleteCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            await _unitOfWork.Repository<Category>().ExecuteDeleteAsync(c => c.Id == id, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            Log.Error("Error During Delete Category By Id From Category Service", ex.Message);
            return false;
        }
    }
}