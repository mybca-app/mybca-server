<!-- Generator: Widdershins v4.0.1 -->

<h1 id="mybca-server-v1">MyBCA.Server | v1 v1.0.0</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

Base URLs:

* <a href="https://main-service-prod-oc1.mybca.link/">https://main-service-prod-oc1.mybca.link/</a>

<h1 id="mybca-server-v1-bus">Bus</h1>

## get__api_Bus_List

> Code samples

`GET /api/Bus/List`

*Retrieves a map of each bus to its position*

> Example responses

> 200 Response

```
{"count":0,"data":{"property1":"string","property2":"string"},"expiry":"2019-08-24T14:15:22Z"}
```

```json
{
  "count": 0,
  "data": {
    "property1": "string",
    "property2": "string"
  },
  "expiry": "2019-08-24T14:15:22Z"
}
```

<h3 id="get__api_bus_list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[BusApiResponse](#schemabusapiresponse)|

<aside class="success">
This operation does not require authentication
</aside>

## get__api_Bus_History

> Code samples

`GET /api/Bus/History`

*Retrieves a history of a bus's arrivals*

<h3 id="get__api_bus_history-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|bus|query|string|false|none|

> Example responses

> 200 Response

```
[{"busName":"string","busPosition":"string","arrivalTime":"2019-08-24T14:15:22Z"}]
```

```json
[
  {
    "busName": "string",
    "busPosition": "string",
    "arrivalTime": "2019-08-24T14:15:22Z"
  }
]
```

<h3 id="get__api_bus_history-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|Inline|

<h3 id="get__api_bus_history-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[BusArrivalDto](#schemabusarrivaldto)]|false|none|none|
|» busName|string¦null|true|none|none|
|» busPosition|string¦null|true|none|none|
|» arrivalTime|string(date-time)|true|none|none|

<aside class="success">
This operation does not require authentication
</aside>

## get__api_Bus_Reports_Generate

> Code samples

`GET /api/Bus/Reports/Generate`

*Generates a CSV report of all bus arrival data*

<h3 id="get__api_bus_reports_generate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|start|query|string(date)|false|none|
|end|query|string(date)|false|none|

<h3 id="get__api_bus_reports_generate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|None|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="mybca-server-v1-link">Link</h1>

## get__api_Links

> Code samples

`GET /api/Links`

*Retrieves a list of quick links to key BCA services*

> Example responses

> 200 Response

```
{"count":0,"data":[{"name":"string","target":"http://example.com"}]}
```

```json
{
  "count": 0,
  "data": [
    {
      "name": "string",
      "target": "http://example.com"
    }
  ]
}
```

<h3 id="get__api_links-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[LinkApiResponse](#schemalinkapiresponse)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="mybca-server-v1-news">News</h1>

## get__api_News_Stories_Latest

> Code samples

`GET /api/News/Stories/Latest`

*Retrieves the latest news story*

> Example responses

> 200 Response

```
{"data":{"id":0,"title":"string","link":"string","imageLink":"string","contentHtml":"string","createdAt":"2019-08-24T14:15:22Z"},"expiry":"2019-08-24T14:15:22Z"}
```

```json
{
  "data": {
    "id": 0,
    "title": "string",
    "link": "string",
    "imageLink": "string",
    "contentHtml": "string",
    "createdAt": "2019-08-24T14:15:22Z"
  },
  "expiry": "2019-08-24T14:15:22Z"
}
```

<h3 id="get__api_news_stories_latest-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[NewsApiResponseOfNewsStoryDto](#schemanewsapiresponseofnewsstorydto)|

<aside class="success">
This operation does not require authentication
</aside>

## get__api_News_Stories

> Code samples

`GET /api/News/Stories`

*Retrieves the top 10 latest news stories*

> Example responses

> 200 Response

```
{"data":[{"id":0,"title":"string","link":"string","imageLink":"string","contentHtml":"string","createdAt":"2019-08-24T14:15:22Z"}],"expiry":"2019-08-24T14:15:22Z"}
```

```json
{
  "data": [
    {
      "id": 0,
      "title": "string",
      "link": "string",
      "imageLink": "string",
      "contentHtml": "string",
      "createdAt": "2019-08-24T14:15:22Z"
    }
  ],
  "expiry": "2019-08-24T14:15:22Z"
}
```

<h3 id="get__api_news_stories-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[NewsApiResponseOfIEnumerableOfNewsStoryDto](#schemanewsapiresponseofienumerableofnewsstorydto)|

<aside class="success">
This operation does not require authentication
</aside>

## get__api_News_Stories_{id}

> Code samples

`GET /api/News/Stories/{id}`

*Retrieves a story by its ID*

<h3 id="get__api_news_stories_{id}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|integer(int32)|true|none|

> Example responses

> 200 Response

```
{"id":0,"title":"string","link":"string","imageLink":"string","contentHtml":"string","createdAt":"2019-08-24T14:15:22Z"}
```

```json
{
  "id": 0,
  "title": "string",
  "link": "string",
  "imageLink": "string",
  "contentHtml": "string",
  "createdAt": "2019-08-24T14:15:22Z"
}
```

<h3 id="get__api_news_stories_{id}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[NewsStoryDto2](#schemanewsstorydto2)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="mybca-server-v1-nutrislice">Nutrislice</h1>

## get__api_Lunch_Week

> Code samples

`GET /api/Lunch/Week`

*Retrieves the lunch menu for the week*

> Example responses

> 200 Response

```
{"data":{"startDate":"string","displayName":"string","days":[{"date":"string","menuItems":[{"date":"2019-08-24T14:15:22Z","position":0,"isSectionTitle":true,"text":"string","food":{"id":0,"name":"string","description":"string","subtext":"string","imageUrl":"string"},"stationID":0,"isStationHeader":true,"image":"string","category":"string"}]}]},"expiry":"2019-08-24T14:15:22Z"}
```

```json
{
  "data": {
    "startDate": "string",
    "displayName": "string",
    "days": [
      {
        "date": "string",
        "menuItems": [
          {
            "date": "2019-08-24T14:15:22Z",
            "position": 0,
            "isSectionTitle": true,
            "text": "string",
            "food": {
              "id": 0,
              "name": "string",
              "description": "string",
              "subtext": "string",
              "imageUrl": "string"
            },
            "stationID": 0,
            "isStationHeader": true,
            "image": "string",
            "category": "string"
          }
        ]
      }
    ]
  },
  "expiry": "2019-08-24T14:15:22Z"
}
```

<h3 id="get__api_lunch_week-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[NutrisliceApiResponseOfMenuWeekDto](#schemanutrisliceapiresponseofmenuweekdto)|

<aside class="success">
This operation does not require authentication
</aside>

## get__api_Lunch_Day

> Code samples

`GET /api/Lunch/Day`

*Retrieves the lunch menu for the day*

> Example responses

> 200 Response

```
{"data":{"date":"string","menuItems":[{"date":"2019-08-24T14:15:22Z","position":0,"isSectionTitle":true,"text":"string","food":{"id":0,"name":"string","description":"string","subtext":"string","imageUrl":"string"},"stationID":0,"isStationHeader":true,"image":"string","category":"string"}]},"expiry":"2019-08-24T14:15:22Z"}
```

```json
{
  "data": {
    "date": "string",
    "menuItems": [
      {
        "date": "2019-08-24T14:15:22Z",
        "position": 0,
        "isSectionTitle": true,
        "text": "string",
        "food": {
          "id": 0,
          "name": "string",
          "description": "string",
          "subtext": "string",
          "imageUrl": "string"
        },
        "stationID": 0,
        "isStationHeader": true,
        "image": "string",
        "category": "string"
      }
    ]
  },
  "expiry": "2019-08-24T14:15:22Z"
}
```

<h3 id="get__api_lunch_day-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[NutrisliceApiResponseOfMenuDayDto](#schemanutrisliceapiresponseofmenudaydto)|

<aside class="success">
This operation does not require authentication
</aside>

<h1 id="mybca-server-v1-schedule">Schedule</h1>

## get__api_Schedule_Day_{date}

> Code samples

`GET /api/Schedule/Day/{date}`

*Retrieves details of the schedule for a day*

<h3 id="get__api_schedule_day_{date}-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|date|path|string(date)|true|none|

> Example responses

> 200 Response

```
{"id":0,"day":"2019-08-24","scheduleId":0,"schedule":{"id":0,"name":"string","items":[{"periodName":"string","startTime":"14:15:22Z","endTime":"14:15:22Z"}]}}
```

```json
{
  "id": 0,
  "day": "2019-08-24",
  "scheduleId": 0,
  "schedule": {
    "id": 0,
    "name": "string",
    "items": [
      {
        "periodName": "string",
        "startTime": "14:15:22Z",
        "endTime": "14:15:22Z"
      }
    ]
  }
}
```

<h3 id="get__api_schedule_day_{date}-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[ScheduleDayDto](#schemascheduledaydto)|

<aside class="success">
This operation does not require authentication
</aside>

# Schemas

<h2 id="tocS_BusApiResponse">BusApiResponse</h2>
<!-- backwards compatibility -->
<a id="schemabusapiresponse"></a>
<a id="schema_BusApiResponse"></a>
<a id="tocSbusapiresponse"></a>
<a id="tocsbusapiresponse"></a>

```json
{
  "count": 0,
  "data": {
    "property1": "string",
    "property2": "string"
  },
  "expiry": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|count|integer(int32)|true|none|none|
|data|object|true|none|none|
|» **additionalProperties**|string|false|none|none|
|expiry|string(date-time)¦null|true|none|none|

<h2 id="tocS_BusArrivalDto">BusArrivalDto</h2>
<!-- backwards compatibility -->
<a id="schemabusarrivaldto"></a>
<a id="schema_BusArrivalDto"></a>
<a id="tocSbusarrivaldto"></a>
<a id="tocsbusarrivaldto"></a>

```json
{
  "busName": "string",
  "busPosition": "string",
  "arrivalTime": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|busName|string¦null|true|none|none|
|busPosition|string¦null|true|none|none|
|arrivalTime|string(date-time)|true|none|none|

<h2 id="tocS_FoodItemDto">FoodItemDto</h2>
<!-- backwards compatibility -->
<a id="schemafooditemdto"></a>
<a id="schema_FoodItemDto"></a>
<a id="tocSfooditemdto"></a>
<a id="tocsfooditemdto"></a>

```json
{
  "id": 0,
  "name": "string",
  "description": "string",
  "subtext": "string",
  "imageUrl": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|integer(int32)|true|none|none|
|name|string¦null|true|none|none|
|description|string¦null|true|none|none|
|subtext|string¦null|true|none|none|
|imageUrl|string¦null|true|none|none|

<h2 id="tocS_LinkApiResponse">LinkApiResponse</h2>
<!-- backwards compatibility -->
<a id="schemalinkapiresponse"></a>
<a id="schema_LinkApiResponse"></a>
<a id="tocSlinkapiresponse"></a>
<a id="tocslinkapiresponse"></a>

```json
{
  "count": 0,
  "data": [
    {
      "name": "string",
      "target": "http://example.com"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|count|integer(int32)|true|none|none|
|data|[[LinkDto](#schemalinkdto)]|true|none|none|

<h2 id="tocS_LinkDto">LinkDto</h2>
<!-- backwards compatibility -->
<a id="schemalinkdto"></a>
<a id="schema_LinkDto"></a>
<a id="tocSlinkdto"></a>
<a id="tocslinkdto"></a>

```json
{
  "name": "string",
  "target": "http://example.com"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string|true|none|none|
|target|string(uri)|true|none|none|

<h2 id="tocS_MenuDayDto">MenuDayDto</h2>
<!-- backwards compatibility -->
<a id="schemamenudaydto"></a>
<a id="schema_MenuDayDto"></a>
<a id="tocSmenudaydto"></a>
<a id="tocsmenudaydto"></a>

```json
{
  "date": "string",
  "menuItems": [
    {
      "date": "2019-08-24T14:15:22Z",
      "position": 0,
      "isSectionTitle": true,
      "text": "string",
      "food": {
        "id": 0,
        "name": "string",
        "description": "string",
        "subtext": "string",
        "imageUrl": "string"
      },
      "stationID": 0,
      "isStationHeader": true,
      "image": "string",
      "category": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|date|string¦null|true|none|none|
|menuItems|[[MenuItemDto](#schemamenuitemdto)]|true|none|none|

<h2 id="tocS_MenuDayDto2">MenuDayDto2</h2>
<!-- backwards compatibility -->
<a id="schemamenudaydto2"></a>
<a id="schema_MenuDayDto2"></a>
<a id="tocSmenudaydto2"></a>
<a id="tocsmenudaydto2"></a>

```json
{
  "date": "string",
  "menuItems": [
    {
      "date": "2019-08-24T14:15:22Z",
      "position": 0,
      "isSectionTitle": true,
      "text": "string",
      "food": {
        "id": 0,
        "name": "string",
        "description": "string",
        "subtext": "string",
        "imageUrl": "string"
      },
      "stationID": 0,
      "isStationHeader": true,
      "image": "string",
      "category": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|date|string¦null|true|none|none|
|menuItems|[[MenuItemDto](#schemamenuitemdto)]|true|none|none|

<h2 id="tocS_MenuItemDto">MenuItemDto</h2>
<!-- backwards compatibility -->
<a id="schemamenuitemdto"></a>
<a id="schema_MenuItemDto"></a>
<a id="tocSmenuitemdto"></a>
<a id="tocsmenuitemdto"></a>

```json
{
  "date": "2019-08-24T14:15:22Z",
  "position": 0,
  "isSectionTitle": true,
  "text": "string",
  "food": {
    "id": 0,
    "name": "string",
    "description": "string",
    "subtext": "string",
    "imageUrl": "string"
  },
  "stationID": 0,
  "isStationHeader": true,
  "image": "string",
  "category": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|date|string(date-time)¦null|true|none|none|
|position|integer(int32)|true|none|none|
|isSectionTitle|boolean|true|none|none|
|text|string¦null|true|none|none|
|food|[FoodItemDto](#schemafooditemdto)|true|none|none|
|stationID|integer(uint32)|true|none|none|
|isStationHeader|boolean|true|none|none|
|image|string¦null|true|none|none|
|category|string¦null|true|none|none|

<h2 id="tocS_MenuWeekDto">MenuWeekDto</h2>
<!-- backwards compatibility -->
<a id="schemamenuweekdto"></a>
<a id="schema_MenuWeekDto"></a>
<a id="tocSmenuweekdto"></a>
<a id="tocsmenuweekdto"></a>

```json
{
  "startDate": "string",
  "displayName": "string",
  "days": [
    {
      "date": "string",
      "menuItems": [
        {
          "date": "2019-08-24T14:15:22Z",
          "position": 0,
          "isSectionTitle": true,
          "text": "string",
          "food": {
            "id": 0,
            "name": "string",
            "description": "string",
            "subtext": "string",
            "imageUrl": "string"
          },
          "stationID": 0,
          "isStationHeader": true,
          "image": "string",
          "category": "string"
        }
      ]
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|startDate|string¦null|true|none|none|
|displayName|string¦null|true|none|none|
|days|[[MenuDayDto](#schemamenudaydto)]|true|none|none|

<h2 id="tocS_NewsApiResponseOfIEnumerableOfNewsStoryDto">NewsApiResponseOfIEnumerableOfNewsStoryDto</h2>
<!-- backwards compatibility -->
<a id="schemanewsapiresponseofienumerableofnewsstorydto"></a>
<a id="schema_NewsApiResponseOfIEnumerableOfNewsStoryDto"></a>
<a id="tocSnewsapiresponseofienumerableofnewsstorydto"></a>
<a id="tocsnewsapiresponseofienumerableofnewsstorydto"></a>

```json
{
  "data": [
    {
      "id": 0,
      "title": "string",
      "link": "string",
      "imageLink": "string",
      "contentHtml": "string",
      "createdAt": "2019-08-24T14:15:22Z"
    }
  ],
  "expiry": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[[NewsStoryDto2](#schemanewsstorydto2)]¦null|true|none|none|
|expiry|string(date-time)¦null|true|none|none|

<h2 id="tocS_NewsApiResponseOfNewsStoryDto">NewsApiResponseOfNewsStoryDto</h2>
<!-- backwards compatibility -->
<a id="schemanewsapiresponseofnewsstorydto"></a>
<a id="schema_NewsApiResponseOfNewsStoryDto"></a>
<a id="tocSnewsapiresponseofnewsstorydto"></a>
<a id="tocsnewsapiresponseofnewsstorydto"></a>

```json
{
  "data": {
    "id": 0,
    "title": "string",
    "link": "string",
    "imageLink": "string",
    "contentHtml": "string",
    "createdAt": "2019-08-24T14:15:22Z"
  },
  "expiry": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[NewsStoryDto](#schemanewsstorydto)|true|none|none|
|expiry|string(date-time)¦null|true|none|none|

<h2 id="tocS_NewsStoryDto">NewsStoryDto</h2>
<!-- backwards compatibility -->
<a id="schemanewsstorydto"></a>
<a id="schema_NewsStoryDto"></a>
<a id="tocSnewsstorydto"></a>
<a id="tocsnewsstorydto"></a>

```json
{
  "id": 0,
  "title": "string",
  "link": "string",
  "imageLink": "string",
  "contentHtml": "string",
  "createdAt": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|integer(int32)|true|none|none|
|title|string|true|none|none|
|link|string|true|none|none|
|imageLink|string¦null|true|none|none|
|contentHtml|string¦null|true|none|none|
|createdAt|string(date-time)|true|none|none|

<h2 id="tocS_NewsStoryDto2">NewsStoryDto2</h2>
<!-- backwards compatibility -->
<a id="schemanewsstorydto2"></a>
<a id="schema_NewsStoryDto2"></a>
<a id="tocSnewsstorydto2"></a>
<a id="tocsnewsstorydto2"></a>

```json
{
  "id": 0,
  "title": "string",
  "link": "string",
  "imageLink": "string",
  "contentHtml": "string",
  "createdAt": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|integer(int32)|true|none|none|
|title|string|true|none|none|
|link|string|true|none|none|
|imageLink|string¦null|true|none|none|
|contentHtml|string¦null|true|none|none|
|createdAt|string(date-time)|true|none|none|

<h2 id="tocS_NutrisliceApiResponseOfMenuDayDto">NutrisliceApiResponseOfMenuDayDto</h2>
<!-- backwards compatibility -->
<a id="schemanutrisliceapiresponseofmenudaydto"></a>
<a id="schema_NutrisliceApiResponseOfMenuDayDto"></a>
<a id="tocSnutrisliceapiresponseofmenudaydto"></a>
<a id="tocsnutrisliceapiresponseofmenudaydto"></a>

```json
{
  "data": {
    "date": "string",
    "menuItems": [
      {
        "date": "2019-08-24T14:15:22Z",
        "position": 0,
        "isSectionTitle": true,
        "text": "string",
        "food": {
          "id": 0,
          "name": "string",
          "description": "string",
          "subtext": "string",
          "imageUrl": "string"
        },
        "stationID": 0,
        "isStationHeader": true,
        "image": "string",
        "category": "string"
      }
    ]
  },
  "expiry": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[MenuDayDto2](#schemamenudaydto2)|true|none|none|
|expiry|string(date-time)¦null|true|none|none|

<h2 id="tocS_NutrisliceApiResponseOfMenuWeekDto">NutrisliceApiResponseOfMenuWeekDto</h2>
<!-- backwards compatibility -->
<a id="schemanutrisliceapiresponseofmenuweekdto"></a>
<a id="schema_NutrisliceApiResponseOfMenuWeekDto"></a>
<a id="tocSnutrisliceapiresponseofmenuweekdto"></a>
<a id="tocsnutrisliceapiresponseofmenuweekdto"></a>

```json
{
  "data": {
    "startDate": "string",
    "displayName": "string",
    "days": [
      {
        "date": "string",
        "menuItems": [
          {
            "date": "2019-08-24T14:15:22Z",
            "position": 0,
            "isSectionTitle": true,
            "text": "string",
            "food": {
              "id": 0,
              "name": "string",
              "description": "string",
              "subtext": "string",
              "imageUrl": "string"
            },
            "stationID": 0,
            "isStationHeader": true,
            "image": "string",
            "category": "string"
          }
        ]
      }
    ]
  },
  "expiry": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[MenuWeekDto](#schemamenuweekdto)|true|none|none|
|expiry|string(date-time)¦null|true|none|none|

<h2 id="tocS_ScheduleDayDto">ScheduleDayDto</h2>
<!-- backwards compatibility -->
<a id="schemascheduledaydto"></a>
<a id="schema_ScheduleDayDto"></a>
<a id="tocSscheduledaydto"></a>
<a id="tocsscheduledaydto"></a>

```json
{
  "id": 0,
  "day": "2019-08-24",
  "scheduleId": 0,
  "schedule": {
    "id": 0,
    "name": "string",
    "items": [
      {
        "periodName": "string",
        "startTime": "14:15:22Z",
        "endTime": "14:15:22Z"
      }
    ]
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|integer(int32)|true|none|none|
|day|string(date)|true|none|none|
|scheduleId|integer(int32)|true|none|none|
|schedule|[ScheduleDto](#schemascheduledto)|true|none|none|

<h2 id="tocS_ScheduleDto">ScheduleDto</h2>
<!-- backwards compatibility -->
<a id="schemascheduledto"></a>
<a id="schema_ScheduleDto"></a>
<a id="tocSscheduledto"></a>
<a id="tocsscheduledto"></a>

```json
{
  "id": 0,
  "name": "string",
  "items": [
    {
      "periodName": "string",
      "startTime": "14:15:22Z",
      "endTime": "14:15:22Z"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|integer(int32)|true|none|none|
|name|string|true|none|none|
|items|[[ScheduleItemDto](#schemascheduleitemdto)]|true|none|none|

<h2 id="tocS_ScheduleItemDto">ScheduleItemDto</h2>
<!-- backwards compatibility -->
<a id="schemascheduleitemdto"></a>
<a id="schema_ScheduleItemDto"></a>
<a id="tocSscheduleitemdto"></a>
<a id="tocsscheduleitemdto"></a>

```json
{
  "periodName": "string",
  "startTime": "14:15:22Z",
  "endTime": "14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|periodName|string|true|none|none|
|startTime|string(time)|true|none|none|
|endTime|string(time)|true|none|none|

