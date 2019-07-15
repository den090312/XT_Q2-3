using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}

public struct Vector2D
{
	public double X { get; private set; }
	public double Y { get; private set; }

	public Vector2D(double X, double Y)
	{
		this.X = X;
		this.Y = Y;
	}

	public static double Distance(Vector2D vec1, Vector2D vec2)
		=> Math.Sqrt((vec1.X - vec2.X) * (vec1.X - vec2.X) + (vec1.Y - vec2.Y) * (vec1.Y - vec2.Y));

}

abstract class GameObject
{
	public readonly string Name;
	public Vector2D Position { get; set; }

	public GameObject(string Name, Vector2D Position)
	{
		this.Name = Name;

		this.Position = Position;
	}

	public abstract void Destroy();

}

abstract class Healthy : GameObject
{
	private int _health;
	public int Health
	{
		get => _health;
		set
		{
			if (_health > value)
				_health = value;
			else throw new ArgumentException("Wrong argument: health cannot be negative or zero.");
		}
	}

	public Healthy(string Name, int Health, Vector2D Position) : base(Name, Position)
	{
		this.Health = Health;
	}

	public virtual void ReceiveDamage(int damage)
	{
		Health -= damage;
	}
}

abstract class Bonus : GameObject
{
	public Bonus(string Name, Vector2D Position) : base(Name, Position)
	{
	}

	public abstract void TakeBonus(Unit recipient);
}

abstract class Obstacle : Healthy
{
	private int _damage;
	public int Damage
	{
		get => _damage;
		set
		{
			if (value >= 0)
				_damage = value;
			else throw new ArgumentException("Wrong argument: damage cannot be negative.");
		}
	}
	public Obstacle(string Name, int Health, Vector2D Position, int Damage) : base(Name, Health, Position)
	{
		this.Damage = Damage;
	}
	public abstract void OnTriggerEnter(Healthy gameObject);

}

abstract class Unit : Healthy
{
	private int _attackDamage;
	public int AttackDamage
	{
		get => _attackDamage;
		set
		{
			if (value > 0)
				_attackDamage = value;
			else throw new ArgumentException("Wrong argument: damage cannot be negative or zero.");
		}
	}

	private int _armor;
	public int Armor
	{
		get => _armor;
		set
		{
			if (_armor > 0)
				_armor = value;
			else if (_armor > 100)
				throw new ArgumentException("Wrong argument: armor cannot be greater then 100.");
			else throw new ArgumentException("Wrong argument: armor cannot be negative or zero.");
		}
	}

	private int _speed;
	public int Speed
	{
		get => _speed;
		set
		{
			if (value > 0)
				_speed = value;
			else throw new ArgumentException("Wrong argument: speed cannot be negative or zero.");
		}
	}

	private double _attackDistance;

	public double AttackDistance
	{
		get =>_attackDistance; 
		set
		{
			if (value > 0)
				_attackDistance = value;
			else throw new ArgumentException("Wrong argument: attack distance cannot be negative or zero.");
		}
	}

	public Unit(string Name, int Health, Vector2D Position, int AttackDamage, int Armor, double AttackDistance, int Speed) : base(Name, Health, Position)
	{
		this.AttackDamage = AttackDamage;
		this.Armor = Armor;
		this.AttackDistance = AttackDistance;
		this.Speed = Speed;
	}

	public abstract void Move();
	public override void ReceiveDamage(int damage)
	{
		float damageReduction = Armor / 100;
		int newDamage = (int)Math.Round(damage * damageReduction);
		base.ReceiveDamage(newDamage);
	}

	public virtual void Attack(Healthy target)
	{
		if (Vector2D.Distance(Position, target.Position) <= _attackDistance)
			target.ReceiveDamage(AttackDamage);
	}
}

class Bomb : Obstacle
{
	public Bomb(int Health, Vector2D Position, int Damage) : base(Name: "Bomb", Health, Position, Damage)
	{
	}

	public override void Destroy()
	{
		throw new NotImplementedException();
	}

	public override void OnTriggerEnter(Healthy gameObject)
	{
		Console.WriteLine("Boooooooooooom!");
		gameObject.ReceiveDamage(Damage);
		Destroy();
	}
}

class Trap : Obstacle
{
	public Trap(Vector2D Position) : base(Name: "Trap", Health: 1, Position, Damage: 30)
	{
	}

	public override void Destroy()
	{
		throw new NotImplementedException();
	}

	public override void OnTriggerEnter(Healthy gameObject)
	{
		gameObject.ReceiveDamage(Damage);
	}
}

class Wolf : Unit
{
	private bool isHungry;
	public Wolf(Vector2D Position) : base(Name:"Wolf", Health:20, Position, AttackDamage: 15, Armor: 4, AttackDistance: 3, Speed: 10)
	{
		isHungry = true;
	}

	public override void Move()
	{
		Vector2D newPoint = FindTargetPosition();
		Position = newPoint;
	}

	private Vector2D FindTargetPosition()
	{
		if (isHungry)
		{
			Random random = new Random();

			double x = random.Next(0, Speed);
			double y = random.Next(0, Speed);
			return new Vector2D(x, y);
		}
		else return Position;
	}

	public override void Destroy()
	{
		throw new NotImplementedException();
	}
}

class Mage : Unit
{
	private int _spellDamage;
	public int SpellDamage
	{
		get { return _spellDamage; }
		set
		{
			if (_spellDamage > 0)
				_spellDamage = value;
			else throw new ArgumentException("Wrong argument: spell damage cannot be negative or zero.");
		}
	}

	public Mage(Vector2D Position, int SpellDamage) : base(Name: "Mage", Health: 100, Position, AttackDamage: 12, Armor: 20, AttackDistance: 15, Speed: 5)
	{
		this.SpellDamage = SpellDamage;
	}

	public override void Destroy()
	{
		throw new NotImplementedException();
	}

	public override void Move()
	{
		Random random = new Random();

		double x = random.Next(0, Speed);
		double y = random.Next(0, Speed);
		Position = new Vector2D(x, y);
	}

	public void FireStorm(Healthy target)
	{
		Console.WriteLine("FIRE STOOOOOOOOOORM!!!!11!!!");
		if (Vector2D.Distance(target.Position, Position) <= AttackDistance)
		{
			for (int i = 0; i < 15; i++)
			{
				target.ReceiveDamage(SpellDamage);
			}
		}
	}
}

class Warrior : Unit
{
	public Warrior(Vector2D Position) : base(Name: "Warrior", Health: 150, Position, AttackDamage: 12, Armor: 20, AttackDistance: 10, Speed: 20)
	{

	}

	public override void Destroy()
	{
		throw new NotImplementedException();
	}

	public override void Move()
	{
		Random random = new Random();

		double x = random.Next(0, Speed);
		double y = random.Next(0, Speed);
		Position = new Vector2D(x, y);
	}

	public void BladeFurry(Healthy target)
	{
		Console.WriteLine("BLADE FURRY!!!!11!!!");
		if (Vector2D.Distance(target.Position, Position) <= AttackDistance)
		{
			for (int i = 0; i < 10; i++)
			{
				target.ReceiveDamage(AttackDamage);
			}
		}
	}
}

class Cherry : Bonus
{
	private int _healthBonus;
	public int HealthBonus
	{
		get { return _healthBonus; }
		set
		{
			if (value > 0)
				_healthBonus = value;
			else throw new ArgumentException("Wrong argument: health bonus cannot be negative or zero.");
		}
	}

	public Cherry(Vector2D position, int HealthBonus) : base(Name: "Cherry", position)
	{
		this.HealthBonus = HealthBonus;
	}

	public override void Destroy()
	{
		throw new NotImplementedException();
	}

	public override void TakeBonus(Unit recipient)
	{
		Console.WriteLine("{0} taked {1}", recipient.Name, Name);
		recipient.Health += HealthBonus;
		Destroy();
	}
}

class Apple : Bonus
{
	private int _speedBonus;
	public int SpeedBonus
	{
		get { return _speedBonus; }
		set
		{
			if (value > 0)
				_speedBonus = value;
			else throw new ArgumentException("Wrong argument: speed bonus cannot be negative or zero.");
		}
	}

	public Apple(Vector2D position, int SpeedBonus) : base(Name: "Apple", position)
	{
		this.SpeedBonus = SpeedBonus;
	}

	public override void Destroy()
	{
		throw new NotImplementedException();
	}

	public override void TakeBonus(Unit recipient)
	{
		Console.WriteLine("{0} taked {1}", recipient.Name, Name);
		recipient.Speed += SpeedBonus;
		Destroy();
	}
}