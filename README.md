SharpRestfulie
==============

Spike on non sequential REST clients with S#arp Arch 2.0 and Restfulie.

The objective is to demo a business requirements change (that will impact the API consumers) without having to update the client application.

Demo for the following business requirements change:
	Current Business process:
		Business has tracks that sells individually for a margin.
			Labels/PSPs and business get their "fair" %.

		Steps:
			Get tracks;
			Add track(s) to basket;
			Submit payment; and
			Get receipt.

	New business process:
		Motivation: PSP is currently getting too much from our business (mainly because the transactions are very low in value). So the business wants to change the services to allow only payments for baskets with value equal to or above £3.
	
	Steps:
		Get tracks;
		Add track(s) to basket;
		Basket value is above or equal to £3?
			No
				Back to step 1;
				
			Yes
				Submit payment; and
				Get receipt.
				

Usage:
	To create the DB execute (explicitly) nUnit test: MappingIntegrationTests.CanCreateDatabase.
	
	Sample API curls:
		Tracks
			Index
				curl http://sharprestfulie.local/tracks -H "Accept: application/json"

			Get 
				curl http://sharprestfulie.local/tracks/1 -H "Accept: application/json"

		Basket
			Create
				curl -v -d "" http://sharprestfulie.local/baskets -H "Accept: application/json"
			
			Get 
				curl http://sharprestfulie.local/baskets/1 -H "Accept: application/json"
				
			Add Track
				curl -v -X POST -d "{\"trackId\":1}" http://sharprestfulie.local/baskets/1/Update -H "Content-Type: application/json" -H "Accept: application/json"

		Payments
			Submit
				curl -v -X POST -d "{\"basketId\":1}" http://sharprestfulie.local/payments -H "Content-Type: application/json" -H "Accept: application/json"
				
			Get Receipt
				curl http://sharprestfulie.local/payments/1 -H "Accept: application/json"