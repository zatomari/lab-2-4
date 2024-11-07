namespace Lab2.Tests;

using Lab2.Word;
using Lab2.Vocabulary;

[TestClass]
public class VocabularyManagerTest {
    [TestMethod]
    public async Task Read() {
        StringReader reader = new StringReader("при;сказ;к;а\n;сказ;;\n");
        Vocabulary vcb = new Vocabulary();

        await VocabularyManager.Read(vcb, reader);

        Assert.IsTrue(vcb.Has("сказ"));
        Assert.IsTrue(vcb.Has("присказка"));
        Assert.IsFalse(vcb.Has("сказка"));
    }

    [TestMethod]
    public async Task Write() {
        Vocabulary vcb = new Vocabulary();
        StringWriter writer = new StringWriter();

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
                new WordPrefix(),
                new WordRoot("сказ"),
                new WordSuffix(),
                new WordEnding()
            )
        );

        await VocabularyManager.Write(vcb, writer);

        Assert.AreEqual(
            "при;сказ;к;а\n;сказ;;\n",
            writer.ToString()
        );
    }
}
