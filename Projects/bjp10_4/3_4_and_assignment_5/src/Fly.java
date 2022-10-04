public class Fly {
    public static void main(String[] args)
	{
		swallowFly();
		swallowSpider();
		swallowBird();
		swallowCat();
		swallowDog();
		swallowHorse();		
	}
	
	public static void swallowFly()
	{
		System.out.println("There was an old lady who swallowed a fly.");
		fly();
	}
	
	public static void fly()
	{
		System.out.println("I don't know why she swallowed that fly,");
		System.out.println("Perhaps she'll die.\n");
	}
	
	public static void swallowSpider()
	{
		System.out.println("There was an old lady who swallowed a spider,");
		System.out.println("That wriggled and iggled and jiggled inside her.");
		spider();
	}
	
	public static void spider()
	{
		System.out.println("She swallowed the spider to catch the fly,");
		fly();
	}
	
	public static void swallowBird()
	{
		System.out.println("There was an old lady who swallowed a bird,");
		System.out.println("How absurd to swallow a bird.");
		bird();
	}
	
	public static void bird()
	{
		System.out.println("She swallowed the bird to catch the spider,");
		spider();
	}
	
	public static void swallowCat()
	{
		System.out.println("There was an old lady who swallowed a cat,");
		System.out.println("Imagine that to swallow a cat.");
		cat();
	}
	
	public static void cat()
	{
		System.out.println("She swallowed the cat to catch the bird,");
		bird();
	}
	
	public static void swallowDog()
	{
		System.out.println("There was an old lady who swallowed a dog,");
		System.out.println("What a hog to swallow a dog.");
		dog();
	}
	
	public static void dog()
	{
		System.out.println("She swallowed the dog to catch the cat,");
		cat();
	}
	
	public static void swallowHorse()
	{
		System.out.println("There was an old lady who swallowed a horse,");
		System.out.println("She died of course.");
	}
}
