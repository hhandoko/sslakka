# -*- mode: ruby -*-
# vi: set ft=ruby :

###
# File     : Vagrantfile
# License  :
#   Copyright (c) 2016 sslakka contributors
#
#   Licensed under the Apache License, Version 2.0 (the "License");
#   you may not use this file except in compliance with the License.
#   You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
#   Unless required by applicable law or agreed to in writing, software
#   distributed under the License is distributed on an "AS IS" BASIS,
#   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
#   See the License for the specific language governing permissions and
#   limitations under the License.
###

# -----------------------------------------------------------------------------
# Configuration
# -----------------------------------------------------------------------------
CFG_HOSTNAME = ENV['VM_NAME'] || "sslakka-svcs0" # Guest VM name
CFG_MEMSIZE = ENV['VM_MEM'] || "1024"            # Allocated max RAM
CFG_CPU_COUNT = ENV['VM_CPU'] || "1"             # Allocated CPU core(s)
CFG_IP = ENV['VM_IP'] || "192.168.100.10"        # Assigned static IP address



# -----------------------------------------------------------------------------
# Vagrant Script
# -----------------------------------------------------------------------------
VAGRANTFILE_API_VERSION = "2"

Vagrant.configure(VAGRANTFILE_API_VERSION) do |config|

  # Use Ubuntu 14.04 LTS (Trusty Tahr) from Ubuntu repository
  config.vm.box = "trusty64"
  config.vm.box_url = "https://cloud-images.ubuntu.com/vagrant/trusty/current/trusty-server-cloudimg-amd64-vagrant-disk1.box"

  # Use `vagrant-cachier` to cache common packages and reduce time to provision boxes
  if Vagrant.has_plugin?("vagrant-cachier")
    # Configure cached packages to be shared between instances of the same base box.
    # More info on http://fgrehm.viewdocs.io/vagrant-cachier/usage
    config.cache.scope = :box
  end

  config.vm.host_name = CFG_HOSTNAME
  config.vm.network :private_network, ip: CFG_IP

  # Run provisioning script
  config.vm.provision :shell, :path => "tools/vagrant/postgresql.sh"

  # Configure guest VM port forwarding
  config.vm.network :forwarded_port, guest: 5432, host: 15432

  # Configure guest VM memory size
  config.vm.provider :virtualbox do |v|
    v.name = CFG_HOSTNAME
    v.customize ["modifyvm", :id, "--memory", CFG_MEMSIZE, "--cpus", CFG_CPU_COUNT]
  end

end