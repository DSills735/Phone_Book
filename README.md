# Phone Book
this will function as a working contact directory or phone book, for personal use. 

**Tech used:** C#, Entity Framework

I learned alot about EF and understand why it is used. The simplicity of using it is awesome. Seems very powerful! I am excited to use it more! I also used Regex for validation, which I have not in a long time. I love the simplicity and power it provides!


## Optimizations

In previous projects, I created 2 different table methods, one to print, and the other to return to a specific destination. I put some thought into how to use the same class for both. It finally dawned on me to just use a boolean statement, which works well. Though, it could possibly be something that is confusing if other developers were involved in the project. 


## Lessons Learned

I learned alot about regex and pattern recognition. As you can see, the email pattern is very extensive. It started as just making sure there was text before an @ symbol, then ensuring there was text, period, text after. The validation turned into what it is now after researching. From what I can tell, It is comprehensive. 

I expanded on my last project in regards to naming conventions. I felt much more confident handling my code, and it felt more natural. I did not feel the need to be referencing other files and did not search for names throughout development. I used more detailed method names where possible, and I divided up a Controller and Service file which helped. I eventually added a user interface file, which was used to display a table and a single contact card. User interaction was handled in the Services file. This probably could have been outsourced to the UI file, though I felt that might be confusing. 


##Testing

This project has a .UnitTesting area. This is my first time In a while writing unit testing. Given the Regex used to validate some inputs, it was important to test various inputs. I did catch some issues with my initial phone number regex expression, which was not inherently wrong, as it allowed the country codes to be added, but it did not follow the expected format for phone number input. This was important for me to change, as I do have a thought to add SMS and Email functionality based on a challenge. This would complicate my thoughts of SMS implementation, as the service I planned on using requires the input I expect to be reformatted. Having several different formats would obviously complicated that, especially when they are unexpected. 
