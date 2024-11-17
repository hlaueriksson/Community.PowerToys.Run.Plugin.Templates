using System.Diagnostics;
using FluentAssertions;

namespace Community.PowerToys.Run.Plugin.Templates.Tests;

public class IntegrationTests
{
    [SetUp]
    public void Setup()
    {
        var template = @"..\..\..\..\src\templates\";
        Delete("hive");
        RunProcess(@$"dotnet new install {template} --debug:custom-hive hive");
    }

    [Test]
    public Task ptrun_sln()
    {
        var output = "MySolution";
        Delete(output);
        var result = RunProcess(@$"dotnet new ptrun-sln -o {output} --debug:custom-hive hive");

        result.ExitCode.Should().Be(0);
        Directory.Exists(output).Should().BeTrue("Output directory was not created.");
        return VerifyDirectory(output);
    }

    [Test]
    public Task ptrun_proj()
    {
        var output = "MyProject";
        Delete(output);
        var result = RunProcess(@$"dotnet new ptrun-proj -o {output} --debug:custom-hive hive");

        result.ExitCode.Should().Be(0);
        Directory.Exists(output).Should().BeTrue("Output directory was not created.");
        return VerifyDirectory(output);
    }

    private static void Delete(string path)
    {
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
    }

    private static ProcessResult RunProcess(string command)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            }
        };

        process.Start();
        var output = process.StandardOutput.ReadToEnd();
        var error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        return new ProcessResult(process.ExitCode, output, error);
    }

    private record ProcessResult(int ExitCode, string Output, string Error);
}
