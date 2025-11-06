namespace Ecommerce.Api.Controllers;

public class CategoryController : BaseApiController
{
    private readonly IMapper _mapper;

    public CategoryController(IMediator mediator, IMapper mapper)
                : base(mediator)
     =>   _mapper = mapper;

    [HttpPost("createCategory")]
    public async Task<IActionResult> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var result = await _mediator.Send(
            new CreateCategoryCommand(
                categoryDto.ArabicName,
                categoryDto.EnglishName,
                categoryDto.ArabicDescription,
                categoryDto.EnglishDescription
                ));

        if (result is null)
        {
            Log.Error($"Cant Create Category With Name {categoryDto.ArabicName ?? categoryDto.EnglishName}");
            return BadRequest(
                new ApiResponse(400, $"Cant Create Category With Name {categoryDto.ArabicName ?? categoryDto.EnglishName}"));
        }

        return Ok(result);
    }

    [HttpGet("getCategoty/{id}")]
    public async Task<IActionResult> GetCategoryAsync(int id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery(id));
        if (category is null)
        {
            Log.Error($"Cant Find Category With Id {id}");
            return NotFound(new ApiResponse(404, $"Cant Find Category With Id {id}"));
        }

        var categoryToReturn = _mapper.Map<Category, CategoryToReturnDto>(category);
        return Ok(categoryToReturn);
    }
    [HttpGet("getAllCategoires")]
    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        var categories = await _mediator.Send(new GetCategoriesQuery());
        if (categories is null || !categories.Any())
        {
            Log.Error("No Categories Found");
            return NotFound(new ApiResponse(404, "No Categories Found"));
        }
        var mappedCategories = _mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryToReturnDto>>(categories ?? []);
        return Ok(mappedCategories);
    }

    [HttpDelete("deleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand(id));
        if (!result)
        {
            Log.Error($"Cant Delete Category With Id {id}");
            return BadRequest(new ApiResponse(400, $"Cant Delete Category With Id {id}"));
        }
        return Ok("Category Deleted Successfully");
    }

    [HttpPatch("updateCategory/{id}")]
    public async Task<IActionResult> UpdateCategoryAsync(int id, UpdatedCategoryDto categoryDto)
    {
        var result = await _mediator.Send(new UpdateCategoryCommand(id,
            categoryDto));
        if (result is null)
        {
            Log.Error($"Cant Update Category With Id {id}");
            return BadRequest(new ApiResponse(400, $"Cant Update Category With Id {id}"));
        }
        return Ok("Category Updated Successfully");
    }
}