namespace Lab1.Tests;

using Lab1.Word;

[TestClass]
public class WordTest {
    [TestMethod]
    public void WordOutput() {
        Assert.AreEqual(
            "пере-при-сказ-к-а",
            new Word(
                new WordPrefix(["пере", "при"]),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            ).Output()
        );

        Assert.AreEqual(
            "сказ-оч-н-ик",
            new Word(
                new WordPrefix(),
                new WordRoot("сказ"),
                new WordSuffix(["оч", "н", "ик"]),
                new WordEnding()
            ).Output()
        );

        Assert.AreEqual(
            "сказ",
            new Word(
                new WordPrefix(),
                new WordRoot("сказ"),
                new WordSuffix(),
                new WordEnding()
            ).Output()
        );

        Assert.AreEqual(
            "при-сказ-к-а",
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            ).Output()
        );

        Assert.AreEqual(
            "рас-сказ",
            new Word(
                new WordPrefix("рас"),
                new WordRoot("сказ"),
                new WordSuffix(""),
                new WordEnding("")
            ).Output()
        );

        Assert.AreEqual(
            "сказ-ы",
            new Word(
                new WordPrefix(""),
                new WordRoot("сказ"),
                new WordSuffix(""),
                new WordEnding("ы")
            ).Output()
        );
    }

    [TestMethod]
    public void WordSerialize() {
        Assert.AreEqual(
            "пере,при;сказ;к;а",
            new Word(
                new WordPrefix(["пере", "при"]),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            ).Serialize()
        );

        Assert.AreEqual(
            ";сказ;оч,н,ик;",
            new Word(
                new WordPrefix(),
                new WordRoot("сказ"),
                new WordSuffix(["оч", "н", "ик"]),
                new WordEnding()
            ).Serialize()
        );

        Assert.AreEqual(
            "при;сказ;к;а",
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            ).Serialize()
        );

        Assert.AreEqual(
            "рас;сказ;;",
            new Word(
                new WordPrefix("рас"),
                new WordRoot("сказ"),
                new WordSuffix(),
                new WordEnding()
            ).Serialize()
        );

        Assert.AreEqual(
            ";сказ;;ы",
            new Word(
                new WordPrefix(),
                new WordRoot("сказ"),
                new WordSuffix(),
                new WordEnding("ы")
            ).Serialize()
        );
    }
}