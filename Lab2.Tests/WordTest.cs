namespace Lab2.Tests;

using Lab2.Word;

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
            new WordDb(
                "пере,при",
                "сказ",
                "к",
                "а"
            ).ToString(),
            new Word(
                new WordPrefix(["пере", "при"]),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            ).Serialize().ToString()
        );

        Assert.AreEqual(
            new WordDb(
                "",
                "сказ",
                "оч,н,ик",
                ""
            ).ToString(),
            new Word(
                new WordPrefix(),
                new WordRoot("сказ"),
                new WordSuffix(["оч", "н", "ик"]),
                new WordEnding()
            ).Serialize().ToString()
        );

        Assert.AreEqual(
            new WordDb(
                "при",
                "сказ",
                "к",
                "а"
            ).ToString(),
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            ).Serialize().ToString()
        );

        Assert.AreEqual(
            new WordDb(
                "рас",
                "сказ",
                "",
                ""
            ).ToString(),
            new Word(
                new WordPrefix("рас"),
                new WordRoot("сказ"),
                new WordSuffix(),
                new WordEnding()
            ).Serialize().ToString()
        );

        Assert.AreEqual(
            new WordDb(
                "",
                "сказ",
                "",
                "ы"
            ).ToString(),
            new Word(
                new WordPrefix(),
                new WordRoot("сказ"),
                new WordSuffix(),
                new WordEnding("ы")
            ).Serialize().ToString()
        );
    }
}