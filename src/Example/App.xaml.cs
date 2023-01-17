// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Example.Contracts.Services;

using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Example
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Host는 다음과 같은 앱의 리소스와 수명 기능을 캡슐화 하는 개체이다.
        /// DI, 로깅, Configuration, 앱 종료, IHostedService 구현
        /// </summary>
        public IHost Host
        {
            get;
        }

        /// <summary>
        /// https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
        /// where 제약 조건
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException">서비스가 아니면 예외처리함</exception>
        public static T GetService<T>()
            where T : class
        {
            // class 가 아니면 true를 반환
            if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
            {
                throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
            }

            // class라면 (App.Current as App)!.Host.Services.GetService(typeof(T))에 해당 하는 값을 service에 할당
            return service;
        }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            Host = Microsoft.Extensions.Hosting.Host;
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);

            await App.GetService<IActivationService>().ActivateAsync(args);
        }
    }
}
