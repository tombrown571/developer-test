
Objective 2 has not been completed.

Missing is saving the Viewing, Adding a db migration, updating the database
and writing tests around this.

However it will proceed in a similar way to adding an Offer to a Property.

i.e. a Buyer submits a Booking Request on a Property.  

I intended this in the form of an email message - to put Buyer and Seller in 
Direct contact with each other - as negotiation here will probably be quicker.

However I can envisage some kind of push request on mobile platform to act as
some kind of messaging service, but for the moment, email is the simpler choice.

I would also write a lot more tests around 


Objective 3.  

General code review.

From this MVC application I can see that the View is tightly coupled to the Controller and Model.

MVC does gives a quick way to write a View - however in my view it becomes complex with adding 
more controllers and views.

This particular style of MVC does address some of the issues, by separating ViewModel creation out
of the Controller - by using Builder classes, and Command Classes

