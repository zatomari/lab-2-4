namespace Lab4.Tests;

using Lab4.Word;
using Lab4.Vocabulary;
using System.Data.Common;

[TestClass]
public class VocabularyTest {
    private static string dbName = "TestDictionary.db";
    [TestMethod]
    public async Task Has() {
        Vocabulary vcb = new Vocabulary(dbName, true);

        vcb.AddWord(
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            )
        );

        Assert.IsTrue(await vcb.Has("присказка"));
    }

    [TestMethod]
    public async Task GetWords() {
        Vocabulary vcb = new Vocabulary(dbName, true);

        vcb.AddWord(
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            )
        );

        Word[] words = await vcb.GetWords("сказ");
        Assert.IsTrue(words.Length == 1);
        Assert.IsTrue(words[0].ToString() == "присказка");
    }

    [TestMethod]
    public async Task GetRoot() {
        Vocabulary vcb = new Vocabulary(dbName, true);

        vcb.AddWord(
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            )
        );

        string root = await vcb.GetRoot("присказка");
        Assert.IsTrue(root == "сказ");
    }

    [TestMethod]
    public async Task GetKnownWords() {
        Vocabulary vcb = new Vocabulary(dbName, true);

        vcb.AddWord(
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            )
        );
        vcb.AddWord(
            new Word(
                new WordPrefix("рас"),
                new WordRoot("сказ"),
                new WordSuffix(),
                new WordEnding()
            )
        );
        vcb.AddWord(
            new Word(
                new WordPrefix(),
                new WordRoot("сказ"),
                new WordSuffix(),
                new WordEnding()
            )
        );

        Word[] words = await vcb.GetKnownWords("сказ");

        Assert.IsTrue(words.Length == 3);
        Assert.IsTrue(words[0].ToString() == "присказка");
        Assert.IsTrue(words[1].ToString() == "рассказ");
        Assert.IsTrue(words[2].ToString() == "сказ");
    }
}
