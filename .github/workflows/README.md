# GitHub Actions Workflows

## Workflows

### `test.yml` - Continuous Integration
Runs on every push and pull request to `main` and `develop` branches.

**Steps:**
1. Restore dependencies
2. Build project (.NET Release)
3. Run tests
4. Upload test results

### `release.yml` - NuGet Release
Runs when a version tag is pushed (e.g., `v0.2.0`)

**Steps:**
1. Build project
2. Run tests
3. Pack NuGet package
4. Publish to NuGet.org
5. Create GitHub Release
6. Upload package artifacts

## Setup Required

### 1. GitHub Secret for NuGet API Key
Add your NuGet API key as a GitHub secret:

```
Settings → Secrets and variables → Actions → New repository secret
Name: NUGET_API_KEY
Value: <your-nuget-api-key>
```

Get your NuGet API key from: https://www.nuget.org/account/ApiKeys

### 2. Tagging for Release

To trigger a release, create a git tag:

```bash
git tag -a v0.2.0 -m "Release version 0.2.0"
git push origin v0.2.0
```

This will:
- Build and test the project
- Pack the NuGet package
- Publish to NuGet.org
- Create a GitHub Release

## Workflow Status

Check workflow status at:
`https://github.com/MarcusMedinaPro/NuGet/actions`

## Version Management

The version in `.csproj` should match the git tag:
- Git tag: `v0.2.0`
- .csproj: `<Version>0.2.0</Version>`
