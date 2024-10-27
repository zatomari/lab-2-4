namespace Lab1.Tests;

using System.Text;

using Lab1.Word;
using Lab1.Vocabulary;

[TestClass]
public class VocabularyTest {
    [TestMethod]
    public void Has() {
        Vocabulary vcb = new Vocabulary();
        vcb.AddWord(
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            )
        );

        Assert.IsTrue(vcb.Has("присказка"));
    }

    [TestMethod]
    public void GetWords() {
        Vocabulary vcb = new Vocabulary();
        vcb.AddWord(
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            )
        );

        Word[] words = vcb.GetWords("сказ");
        Assert.IsTrue(words.Length == 1);
        Assert.IsTrue(words[0].ToString() == "присказка");
    }

    [TestMethod]
    public void GetRoot() {
        Vocabulary vcb = new Vocabulary();
        vcb.AddWord(
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            )
        );

        string root = vcb.GetRoot("присказка");
        Assert.IsTrue(root == "сказ");
    }

    [TestMethod]
    public void GetKnownWords() {
        Vocabulary vcb = new Vocabulary();
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

        Word[] words = vcb.GetKnownWords("сказ").ToArray();

        Assert.IsTrue(words.Length == 3);
        Assert.IsTrue(words[0].ToString() == "сказ");
        Assert.IsTrue(words[1].ToString() == "рассказ");
        Assert.IsTrue(words[2].ToString() == "присказка");
    }
}
