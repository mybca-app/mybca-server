<!-- Generator: Widdershins v4.0.1 -->

<h1 id="mybca-server-v1">MyBCA.Server | v1 v1.0.0</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

Base URLs:

* <a href="https://mybca.link/">https://mybca.link/</a>

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

## get__api_Bus_{bus}_History

> Code samples

`GET /api/Bus/{bus}/History`

*Retrieves a history of a bus's arrivals*

<h3 id="get__api_bus_{bus}_history-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|bus|path|string|true|none|

> Example responses

> 200 Response

```
[{"id":0,"busName":"string","busPosition":"string","arrivalTime":"2019-08-24T14:15:22Z"}]
```

```json
[
  {
    "id": 0,
    "busName": "string",
    "busPosition": "string",
    "arrivalTime": "2019-08-24T14:15:22Z"
  }
]
```

<h3 id="get__api_bus_{bus}_history-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|Inline|

<h3 id="get__api_bus_{bus}_history-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[BusArrival](#schemabusarrival)]|false|none|none|
|» id|integer(int32)|false|none|none|
|» busName|string¦null|true|none|none|
|» busPosition|string¦null|true|none|none|
|» arrivalTime|string(date-time)|false|none|none|

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

## get__api_News_Latest

> Code samples

`GET /api/News/Latest`

*Retrieves the latest news story*

> Example responses

> 200 Response

```
{"data":{"title":"string","link":"string","imageLink":"string","createdAt":"2019-08-24T14:15:22Z"},"expiry":"2019-08-24T14:15:22Z"}
```

```json
{
  "data": {
    "title": "string",
    "link": "string",
    "imageLink": "string",
    "createdAt": "2019-08-24T14:15:22Z"
  },
  "expiry": "2019-08-24T14:15:22Z"
}
```

<h3 id="get__api_news_latest-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[NewsApiResponseOfNewsStory](#schemanewsapiresponseofnewsstory)|

<aside class="success">
This operation does not require authentication
</aside>

## get__api_News_List

> Code samples

`GET /api/News/List`

*Retrieves the top 10 latest news stories*

> Example responses

> 200 Response

```
{"data":{"title":"string","link":"string","imageLink":"string","createdAt":"2019-08-24T14:15:22Z"},"expiry":"2019-08-24T14:15:22Z"}
```

```json
{
  "data": {
    "title": "string",
    "link": "string",
    "imageLink": "string",
    "createdAt": "2019-08-24T14:15:22Z"
  },
  "expiry": "2019-08-24T14:15:22Z"
}
```

<h3 id="get__api_news_list-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[NewsApiResponseOfNewsStory](#schemanewsapiresponseofnewsstory)|

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
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[NutrisliceApiResponseOfMenuWeek](#schemanutrisliceapiresponseofmenuweek)|

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
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[NutrisliceApiResponseOfMenuDay](#schemanutrisliceapiresponseofmenuday)|

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

<h2 id="tocS_BusArrival">BusArrival</h2>
<!-- backwards compatibility -->
<a id="schemabusarrival"></a>
<a id="schema_BusArrival"></a>
<a id="tocSbusarrival"></a>
<a id="tocsbusarrival"></a>

```json
{
  "id": 0,
  "busName": "string",
  "busPosition": "string",
  "arrivalTime": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|integer(int32)|false|none|none|
|busName|string¦null|true|none|none|
|busPosition|string¦null|true|none|none|
|arrivalTime|string(date-time)|false|none|none|

<h2 id="tocS_FoodItem">FoodItem</h2>
<!-- backwards compatibility -->
<a id="schemafooditem"></a>
<a id="schema_FoodItem"></a>
<a id="tocSfooditem"></a>
<a id="tocsfooditem"></a>

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

<h2 id="tocS_Link">Link</h2>
<!-- backwards compatibility -->
<a id="schemalink"></a>
<a id="schema_Link"></a>
<a id="tocSlink"></a>
<a id="tocslink"></a>

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
|data|[[Link](#schemalink)]|true|none|none|

<h2 id="tocS_MenuDay">MenuDay</h2>
<!-- backwards compatibility -->
<a id="schemamenuday"></a>
<a id="schema_MenuDay"></a>
<a id="tocSmenuday"></a>
<a id="tocsmenuday"></a>

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
|menuItems|[[MenuItem](#schemamenuitem)]|true|none|none|

<h2 id="tocS_MenuDay2">MenuDay2</h2>
<!-- backwards compatibility -->
<a id="schemamenuday2"></a>
<a id="schema_MenuDay2"></a>
<a id="tocSmenuday2"></a>
<a id="tocsmenuday2"></a>

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
|menuItems|[[MenuItem](#schemamenuitem)]|true|none|none|

<h2 id="tocS_MenuItem">MenuItem</h2>
<!-- backwards compatibility -->
<a id="schemamenuitem"></a>
<a id="schema_MenuItem"></a>
<a id="tocSmenuitem"></a>
<a id="tocsmenuitem"></a>

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
|food|[FoodItem](#schemafooditem)|true|none|none|
|stationID|integer(uint32)|true|none|none|
|isStationHeader|boolean|true|none|none|
|image|string¦null|true|none|none|
|category|string¦null|true|none|none|

<h2 id="tocS_MenuWeek">MenuWeek</h2>
<!-- backwards compatibility -->
<a id="schemamenuweek"></a>
<a id="schema_MenuWeek"></a>
<a id="tocSmenuweek"></a>
<a id="tocsmenuweek"></a>

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
|days|[[MenuDay](#schemamenuday)]|true|none|none|

<h2 id="tocS_NewsApiResponseOfNewsStory">NewsApiResponseOfNewsStory</h2>
<!-- backwards compatibility -->
<a id="schemanewsapiresponseofnewsstory"></a>
<a id="schema_NewsApiResponseOfNewsStory"></a>
<a id="tocSnewsapiresponseofnewsstory"></a>
<a id="tocsnewsapiresponseofnewsstory"></a>

```json
{
  "data": {
    "title": "string",
    "link": "string",
    "imageLink": "string",
    "createdAt": "2019-08-24T14:15:22Z"
  },
  "expiry": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[NewsStory](#schemanewsstory)|true|none|none|
|expiry|string(date-time)¦null|true|none|none|

<h2 id="tocS_NewsStory">NewsStory</h2>
<!-- backwards compatibility -->
<a id="schemanewsstory"></a>
<a id="schema_NewsStory"></a>
<a id="tocSnewsstory"></a>
<a id="tocsnewsstory"></a>

```json
{
  "title": "string",
  "link": "string",
  "imageLink": "string",
  "createdAt": "2019-08-24T14:15:22Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|title|string|true|none|none|
|link|string|true|none|none|
|imageLink|string¦null|true|none|none|
|createdAt|string(date-time)|true|none|none|

<h2 id="tocS_NutrisliceApiResponseOfMenuDay">NutrisliceApiResponseOfMenuDay</h2>
<!-- backwards compatibility -->
<a id="schemanutrisliceapiresponseofmenuday"></a>
<a id="schema_NutrisliceApiResponseOfMenuDay"></a>
<a id="tocSnutrisliceapiresponseofmenuday"></a>
<a id="tocsnutrisliceapiresponseofmenuday"></a>

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
|data|[MenuDay2](#schemamenuday2)|true|none|none|
|expiry|string(date-time)¦null|true|none|none|

<h2 id="tocS_NutrisliceApiResponseOfMenuWeek">NutrisliceApiResponseOfMenuWeek</h2>
<!-- backwards compatibility -->
<a id="schemanutrisliceapiresponseofmenuweek"></a>
<a id="schema_NutrisliceApiResponseOfMenuWeek"></a>
<a id="tocSnutrisliceapiresponseofmenuweek"></a>
<a id="tocsnutrisliceapiresponseofmenuweek"></a>

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
|data|[MenuWeek](#schemamenuweek)|true|none|none|
|expiry|string(date-time)¦null|true|none|none|

