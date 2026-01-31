using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PickleballClubManagement.Dtos;
using PickleballClubManagement.Models;
using PickleballClubManagement.Services;

namespace PickleballClubManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChallengesController : ControllerBase
{
    private readonly IChallengeService _challengeService;

    public ChallengesController(IChallengeService challengeService)
    {
        _challengeService = challengeService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Challenge>>> GetChallenges()
    {
        var challenges = await _challengeService.GetAllChallengesAsync();
        return Ok(challenges);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Challenge>> GetChallenge(int id)
    {
        var challenge = await _challengeService.GetChallengeByIdAsync(id);
        if (challenge == null)
        {
            return NotFound();
        }

        return Ok(challenge);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Challenge>> CreateChallenge([FromBody] Challenge challenge)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdChallenge = await _challengeService.CreateChallengeAsync(challenge);
        return CreatedAtAction(nameof(GetChallenge), new { id = createdChallenge.Id }, createdChallenge);
    }

    [HttpPost("{challengeId}/join")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> JoinChallenge(int challengeId, [FromBody] JoinChallengeRequest request)
    {
        var result = await _challengeService.JoinChallengeAsync(challengeId, request.MemberId);
        if (!result)
        {
            return BadRequest("Cannot join challenge");
        }

        return Ok(new { message = "Successfully joined challenge" });
    }

    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Challenge>> UpdateChallenge(int id, [FromBody] Challenge challenge)
    {
        var updatedChallenge = await _challengeService.UpdateChallengeAsync(id, challenge);
        if (updatedChallenge == null)
        {
            return NotFound();
        }

        return Ok(updatedChallenge);
    }

    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteChallenge(int id)
    {
        var result = await _challengeService.DeleteChallengeAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
