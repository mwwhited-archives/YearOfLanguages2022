package us.whited.home;

import com.github.fracpete.simpleargparse4j.ArgumentParser;
import com.github.fracpete.simpleargparse4j.ArgumentParserException;
import com.github.fracpete.simpleargparse4j.Namespace;

/**
 * Hello world!
 *
 */
public class App
{
    public static void main(String[] args)
    {
        // https://github.com/fracpete/simple-argparse4j
        ArgumentParser parser = new ArgumentParser("create");
        parser.addOption("--test").dest("test").help("name of the environment")
                .required(true);

        try
        {
            Namespace ns = parser.parseArgs(args);

            System.out.println("test: " + ns.getString("test"));
            System.out.println("Hello World!");
        }
        catch (ArgumentParserException e)
        {
            e.printStackTrace();
        }
    }
}
