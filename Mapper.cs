using System;

public class Mapper: Profile
{
	CreateMap<Order, OrderDTO>().Formember .ReversMap();
	public Mapper()
	{
		
	}
}
