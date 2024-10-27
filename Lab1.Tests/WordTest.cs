namespace Lab1.Tests;

using Lab1.Word;

[TestClass]
public class WordTest {
    [TestMethod]
    public void WordOutput() {
        // НЕПРАВИЛЬНО
        Assert.AreEqual(
            "-сказ-",
            new Word(
                new WordPrefix(""),
                new WordRoot("сказ"),
                new WordSuffix(""),
                new WordEnding("")
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
    }

    [TestMethod]
    public void WordSerialize() {
        Assert.AreEqual(
            "при;сказ;к;а",
            new Word(
                new WordPrefix("при"),
                new WordRoot("сказ"),
                new WordSuffix("к"),
                new WordEnding("а")
            ).Serialize()
        );
    }
}