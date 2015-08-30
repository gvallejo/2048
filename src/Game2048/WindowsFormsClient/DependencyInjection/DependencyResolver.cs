using IoC;
using Ninject;
using Ninject.Parameters;
using Ninject.Activation;
using Ninject.Modules;
using _2048.Engine.IO;
using _2048.Engine.Game;
using _2048.Engine.AI;

namespace WindowsFormsClient.DependencyInjection
{
    public class DependencyResolver : NinjectModule, IResolver
    {

        private readonly StandardKernel _kernel;
        public DependencyResolver()
        {
            _kernel = new StandardKernel(this);
        }

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        public override void Load()
        {
            Bind<IBoard>().To<Board>();
            Bind<IGameInput>().To<GameInput>();
            Bind<IGameOutput>().To<GameOutput>();
            Bind<IMoveProcessor>().To<MoveProcessor>();
            Bind<IAIModule>().To<AIModule>();
            Bind<ITileGenerator>().To<TileGenerator>();

            Bind<IGameEngine>().ToProvider(new GameEngineProvider());


        }

        class GameEngineProvider : Provider<GameEngine>
        {
            protected override GameEngine CreateInstance(IContext context)
            {
                IBoard board = context.Kernel.Get<IBoard>();

                return new GameEngine(board, 
                    context.Kernel.Get<IMoveProcessor>(new [] {new ConstructorArgument("board", board) }),
                   context.Kernel.Get<IAIModule>() , context.Kernel.Get<IGameInput>(), context.Kernel.Get<IGameOutput>());
            }
        }

        

    }
}
