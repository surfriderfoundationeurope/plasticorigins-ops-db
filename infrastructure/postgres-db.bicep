param administratorLogin string = 'po_admin_prod'
@secure()
param administratorPassword string

@allowed([
  'dev'
  'prod'
])
param environment string = 'dev'

var serverName = 'pgdb-plastico-${environment}-fra'

var location = 'francecentral'

resource postGres 'Microsoft.DBforPostgreSQL/flexibleServers@2022-12-01' = {
  name: serverName
  location: location
  tags: {
    environment: environment
  }
  sku: {
    name: 'Standard_B1ms'
    tier: 'Burstable'
  }
  properties: {
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorPassword
    authConfig: {
      activeDirectoryAuth: 'Enabled'
      passwordAuth: 'Enabled'
      tenantId: '1fb581f3-43ef-4dfd-b8f7-4ca7bc32ec24'
    }
    backup: {
      backupRetentionDays: 7
      geoRedundantBackup: 'Disabled'
    }
    createMode: 'string'
    dataEncryption: {
      type: 'SystemManaged'
    }
    highAvailability: {
      mode: 'Disabled'
    }
    maintenanceWindow: {
      customWindow: 'Disabled'
      dayOfWeek: 0
      startHour: 0
      startMinute: 0
    }
    // replicaCapacity: int
    // replicationRole: 'string'
    storage: {
      storageSizeGB: 32
    }
    version: '14'
  }
}
