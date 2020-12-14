<h1><center>设计模式总结</center></h1>

## 一、单例模式（Singleton Pattern）

* 动机：

  * 在软件系统中，经常有这样一些特殊的类，必须保证它们在系统中只存在一个实例，才能确保它们的逻辑正确性、以及良好的效率。
  * **这应该是类设计者的责任，而不是类使用者的责任。**

* 结构图：

  * ![img](https://www.cnblogs.com/images/cnblogs_com/abcdwxc/PIC030.JPG "单例模式")

* 意图：

  * 保证一个类仅有一个实例，并提供一个访问它的全局访问点。

    ​                                                         ——《设计模式》GOF

  * ![img](https://www.cnblogs.com/images/cnblogs_com/abcdwxc/PIC031.jpg)

* 适用性：

  * 当类只能有一个实例而且客户可以从一个众所周知的访问点访问它时。
  * 当这个唯一实例应该是通过子类化可扩展的，并且客户应该无需更改代码就能使用一个扩展的实例时。

* 代码实现：

  * 单线程Singleton实现

    ```c#
    class SingleThread_Singleton
    {
        private static SingleThread_Singleton instance=null;
        private SingleThread_Singleton(){}
        public static SingleThread_Singleton instance
        {
            get
            {
                if(instance==null)
                {
                    instance=new SingleThread_Singleton();
                }
                return instance;
            }
        }
    }
    ```

    * 以上代码在单线程情况下不会出现任何问题。但在多线程情况下却不安全。
      * 如两个线程同时运行到if(instance==null)判断是否被实例化，一个线程判断为true后，在进行创建instance=new SingleThread_Singleton();之前，另一个线程也判断(instance==null),结果也为true。
      * 这就违背了Singleton模式的原则（保证一个类仅有一个实例）。

  * 多线程Singleton实现

    ```c#
    class MultiThread_Singleton
    {
        private static volatile MultiThread_Singleton instance=null;
        private static object lockHelper=new object();
        private MultiThread_Singleton(){}
        public static MultiThread_Singleton
        {
            get
            {
                if(instance==null)
                {
                    lock(lockHelper)
                    {
                        if(instance==null)
                        {
                            instance=new MultiThread_Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
    ```

    * 此程序对多线程是安全的，使用一个辅助对象lockHelper ，保证只有一个线程创建实例（如果instance为空，保证只有一个线程instance=new MultiThread_Singleton(); 创建唯一的实例。（double check）
    * 要注意一个关键字***volatile***，如果去掉这个关键字，还是有可能发生线程是不安全的。volatile保证严格意义的多线程编译器在编译代码时对指令不进行微调。

  * 静态Singleton实现

    ```c#
    class Static_Singleton
    {
        public static readonly Static_Singleton instance=new static_Singleton();
        private Static_Singleton(){}
    }
    //以上代码展开等同于
    class Static_Singleton
    {
        public static readonly Static_Singleton instance;
        static Static_Singleton()
        {
            instance=new Static_Singleton();
        }
        private Static_Singleton();
    }
    ```

    * 优点：简洁，易懂
    * 缺点：不可以实现带参数实例的创建

+++

## 二、享元模式（Flyweight Pattern）

* 动机：

  *  采用纯粹对象方案的问题在于大量细粒度的对象会很快充斥在系统中，从而带来很高的运行时代价——主要指内存需求方面的代价。

* 意图：

  * 运用共享技术有效地支持大量细粒度的对象。

    ​                               ——《设计模式》GOF

  * 结构：

    ![img](https://www.cnblogs.com/images/cnblogs_com/abcdwxc/flyweight_1.gif "享元模式")

* 适用性：

  当以下条件都满足时，可以考虑使用享元模式：

  1. 一个系统有大量的对象
  2. 这些对象耗费大量的内存
  3. 这些对象的状态中的大部分都可以外部化
  4. 这些对象可以按照内蕴状态分为很多的组，当把外蕴对象从对象中剔除时，每一个组都可以仅用一个对象代替
  5. 软件系统不依赖于这些对象的身份，换言之，这些对象是不可分辨的

  满足以上的这些条件的系统可以使用享元对象。最后使用享元模式需要维护一个记录了系统已有的所有享元的表，而这需要耗费资源。因此，应当在有足够多的享元实例可供共享时，才值得使用享元模式。

* 代码实现：

  ```c#
  //创建角色抽象类
  namespace DesignMode
  {
      public abstract class ICharacter
      {
          public CharacterBaseAttr mBaseAttr;
   
          public ICharacter()
          {
          }
      }
  }
  //创建角色实体类
  namespace DesignMode
  {
      public class SoldierCaptain:ICharacter
      {
      }
  }
  namespace DesignMode
  {
      public class SoldierRookie:ICharacter
      {
      }
  }
  namespace DesignMode
  {
      public class SoldierSergeant:ICharacter
      {
      }
  }
  ```

---

## 三、工厂方法模式（Factory Method）

- 动机：

  - 在软件系统中，由于需求的变化，“**这个对象的具体实现经常面临着剧烈的变化**”，但它却**有比较稳定的接口**。
  -  如何应对这种变化呢？提供一种封装机制来隔离出"这个易变对象"的变化，从而保持系统中"其它依赖的对象"不随需求的变化而变化。

- 意图：

  - 定义一个用户创建对象的接口，让子类决定实例哪一个类。Factory Method使一个类的实例化延迟到子类。

    ​                                                      ——《设计模式》GOF

- 结构图：

  - ![img](https://www.cnblogs.com/images/cnblogs_com/abcdwxc/FactoryMethod2.JPG "工厂方法模式")

- 适用性：

  1. 当一个类不知道它所必须创建的对象类的时候
  2. 当一个类希望由它子类来指定它所创建的对象的时候
  3. 当类将创建对象的职责委托给多个帮助子类中的某个，并且你希望将哪一个帮助子类是代理类者这一信息局部化的时候

- 代码实现：

  ```c#
  //坦克工厂接口
  interface ITankFactory 
  {
      TankBase CreateTank(GameObject go);
  }
  //坦克A工厂类
  public class TankAFactory : ITankFactory
  {
      public TankBase CreateTank(GameObject go)
      {
          TankBase tankBase= GameObject.Instantiate<GameObject>(go).GetComponent<TankBase>();
          tankBase.InitTank(2,100);
          return tankBase;
      }
  }
  //坦克B工厂类
  public class TankBFactory : ITankFactory
  {
      public TankBase CreateTank(GameObject go)
      {
          TankBase tankBase = GameObject.Instantiate<GameObject>(go).GetComponent<TankBase>();
          tankBase.InitTank(4, 200);
          return tankBase;
      }
  }
  ```

---

## 四、状态模式（State Pattern）

* 动机：

  * 在软件构建过程中，某些对象的状态如果改变以及其行为也会随之而发生变化，比如文档处于只读状态，其支持的行为和读写状态支持的行为就可能完全不同。
  * 如何在运行时根据对象的状态来透明更改对象的行为？而不会为对象操作和状态转化之间引入紧耦合？

* 意图：

  * 允许一个对象在其内部状态改变时改变它的行为，从而使对象看起来对象似乎修改了其行为。

  ​                                                                   ——《设计模式》GOF

* 结构图：

  * ![img](https://www.cnblogs.com/images/cnblogs_com/abcdwxc/State11.JPG "状态模式")

* 适用性：

  1. 一个对象的行为取决于它的状态，并且它必须在运行时刻根据状态改变它的行为。
  2. 一个操作中含有庞大的多分支的等条件语句，且这些分支依赖于该对象的状态。这个状态通常用一个或多个枚举常量表示。通常，有多个操作包含这一相同的条件结构。State模式将每一个分支放入一个独立的类中。这使得你可根据对象自身的情况将对象的状态作为一个对象，这一对象可以不依赖于其他对象而独立变化。

* 代码实现：

  ```c#
  //抽象类，定义僵尸的状态之间的链接
  public abstract class BaseState
  {
      public abstract void AIState(ZombieTest state);
  }
  //状态实现
  //设置僵尸开始时的状态
  public class NormalState : BaseState
  {
      public override void AIState(ZombieTest state)
      {
           Debug.Log("僵尸目前正在游荡状态，小心！");
      }
  }
  //设置僵尸追击时的状态
  public class ChasingState : BaseState
  {
      public override void AIState(ZombieTest state)
      {
          state.SetState(new AttackState());
          Debug.Log("僵尸正在攻击玩家");
      }
  }
  //僵尸状态的对外接口
  public class ZombieTest : MonoBehaviour
  {
      public BaseState currentState;
  
      /// <summary>
      /// 负责僵尸状态的设置
      /// </summary>
      /// <param name="state"></param>
      public void SetState(BaseState state)
      {
          currentState = state;
      }
  
      /// <summary>
      /// 负责僵尸状态的更新
      /// </summary>
      public void Update()
      {
          if(distance>5)
          {
              SetState(new NormalState());
              currentState.AIState(this);
          }
          else
          {
              SetState(new ChasingState());
              currentState.AIState(this);
          }
      }
  
      /// <summary>
      /// 返回玩家与僵尸之间的距离
      /// </summary>
      /// <returns></returns>
      public float distance()
      {
          Vector3 playerVector3 = Player.transform.position;
          Vector3 zombieVector3 = zombieTransform.position;
          float distanceVector3 = Vector3.Distance(playerVector3, zombieVector3);
          return distanceVector3;
      }
  
  }
  ```

---

## 五、命令模式（Command Pattern）

* 动机：

  *  在软件系统中，“行为请求者”与“行为实现者”通常呈现一种“紧耦合”。但在某些场合，比如要对行为进行“记录、撤销/重做、事务”等处理，这种无法抵御变化的紧耦合是不合适的。
  * 在这种情况下，如何将“行为请求者”与“行为实现者”解耦？将一组行为抽象为对象，可以实现二者之间的松耦合。

* 意图：

  * 将一个请求封装为一个对象，从而使你可用不同的请求对客户进行参数化；对请求排队或记录请求日志，以及支持可撤消的操作。

    ​                                                               ——《设计模式》GOF

* 结构图：

  * ![img](https://www.cnblogs.com/images/cnblogs_com/abcdwxc/Command_01.gif "命令模式")

* 适用性：

  1. 使用命令模式作为"CallBack"在面向对象系统中的替代。"CallBack"讲的便是先将一个函数登记上，然后在以后调用此函数。
  2. 需要在不同的时间指定请求、将请求排队。一个命令对象和原先的请求发出者可以有不同的生命期。换言之，原先的请求发出者可能已经不在了，而命令对象本身仍 然是活动的。这时命令的接收者可以是在本地，也可以在网络的另外一个地址。命令对象可以在串形化之后传送到另外一台机器上去。
  3. 系统需要支持命令的撤消(undo)。命令对象可以把状态存储起来，等到客户端需要撤销命令所产生的效果时，可以调用undo()方法，把命令所产生的效果撤销掉。命令对象还可以提供redo()方法，以供客户端在需要时，再重新实施命令效果。
  4. 如果一个系统要将系统中所有的数据更新到日志里，以便在系统崩溃时，可以根据日志里读回所有的数据更新命令，重新调用Execute()方法一条一条执行这些命令，从而恢复系统在崩溃前所做的数据更新。

* 代码实现：

  ```c#
   private Stack<Command> mCommandStack;
  
   // Use this for initialization
   void Start()
   {
      mCommandStack = new Stack<Command>();
   }
  ```