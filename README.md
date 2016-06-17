## sslakka = ServiceStack + Akka.NET [![Master Build Status](https://travis-ci.org/hhandoko/sslakka.svg?branch=master)](https://travis-ci.org/hhandoko/sslakka)

`sslakka` is a team communication and collaboration tool inspired by [Slack], to demonstrate and validate [ServiceStack] and [Akka.NET] technology stack working in harmony.

Feel free to open any Pull Request (PR) or issues if you see things that can be improved or fixed. Visit [sslakka HuBoard] for its development roadmap.

*NOTE: You will need an active [ServiceStack subscription] to run this application.*

## Prerequisites

### Develop and Compile Dependencies

The application is developed and tested on the following platform and services (i.e. tech stack):

  - [.NET] v4.5+ (Windows), or
  - [Mono] v4.4+ (Linux, OSX)
  - [PostgreSQL] v9.5.x

IDEs (Integrated Development Environment) are a matter of preference, however this application is being developed using various IDEs on OSX El Capitan and Ubuntu 14.04 LTS interchangeably:

  - [Xamarin Studio Community] v6.0,
  - [MonoDevelop] v5.10, and
  - [JetBrains Rider EAP] build 146.1908

*NOTE: JetBrains Rider is still in preview, thus for a number of tasks (e.g. bootstrapping) Xamarin Studio or MonoDevelop is more suitable. However, the above goes to show that the application can be developed on either IDEs on either OS.*

### Services Dependencies

Vagrant is used to provision the necessary services (e.g. database) in an Ubuntu guest VM (1 core, 1GB RAM). The following applications are required to be installed to suport it:

  * [Oracle VM VirtualBox] v5.x
  * [Vagrant] v1.8.x

Quick Vagrant command list (run it in the project root directory):

  * `vagrant up` provisions the services VM
  * `vagrant status` show the services VM status
  * `vagrant global-status` show all Vagrant VM on the machine
  * `vagrant halt` suspends the services VM
  * `vagrant destroy` deletes the services VM

*NOTE: PostgreSQL will be available on `localhost:15432` or `192.168.100.10:5432`. PostgreSQL localhost port forwarding is setup at port `15432`` to avoid conflict with existing PostgreSQL installation.*
  
The following Vagrant plugins are not mandatory, but help speed up box provisioning by caching common packages and update Guest Additions to the latest version automatically:

  * [vagrant-cachier]
  * [vagrant-vbguest]

## Contributing

We follow the "[fork-and-pull]" Git workflow.

  1. Fork the repo on GitHub
  1. Commit changes to a branch in your fork (use `snake_case` convention):
     - For technical chores, use `chore/` prefix followed by the short description, e.g. `chore/do_this_chore`
     - For new features, use `feature/` prefix followed by the feature name, e.g. `feature/feature_name`
     - For bug fixes, use `bug/` prefix followed by the short description, e.g. `bug/fix_this_bug`
  1. Rebase or merge from "upstream"
  1. Submit a PR "upstream" with your changes

Please read [CONTRIBUTING] for more details.

## License

`sslakka` is released under the Apache 2 License. See the [LICENSE] file for further details.

## Thanks

> "If I have seen further, it is by standing on the shoulder of giants."
>    http://en.wikipedia.org/wiki/Standing_on_the_shoulders_of_giants

Many thanks to all you developers and open-source contributors who made this project possible :)

[.NET]: http://www.asp.net
[Akka.NET]: http://getakka.net
[CONTRIBUTING]: CONTRIBUTING.md
[fork-and-pull]: https://help.github.com/articles/using-pull-requests
[JetBrains Rider EAP]: https://www.jetbrains.com/rider/
[LICENSE]: LICENSE.txt
[Mono]: http://www.mono-project.com
[MonoDevelop]: http://www.monodevelop.com/
[Oracle VM VirtualBox]: https://www.virtualbox.org
[PostgreSQL]: http://www.postgresql.org/download/
[ServiceStack]: https://servicestack.net
[ServiceStack subscription]: https://servicestack.net/pricing
[Slack]: https://slack.com
[sslakka HuBoard]: https://huboard.com/hhandoko/sslakka/
[Vagrant]: https://www.vagrantup.com
[vagrant-cachier]: https://github.com/fgrehm/vagrant-cachier
[vagrant-vbguest]: https://github.com/dotless-de/vagrant-vbguest
[Xamarin Studio Community]: https://www.xamarin.com/studio
