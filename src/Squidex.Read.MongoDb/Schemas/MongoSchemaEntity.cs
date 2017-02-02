﻿// ==========================================================================
//  MongoSchemaEntity.cs
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex Group
//  All rights reserved.
// ==========================================================================

using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Linq;
using Squidex.Core.Schemas;
using Squidex.Core.Schemas.Json;
using Squidex.Infrastructure;
using Squidex.Infrastructure.MongoDb;
using Squidex.Read.Schemas;

namespace Squidex.Read.MongoDb.Schemas
{
    public sealed class MongoSchemaEntity : MongoEntity, ISchemaEntityWithSchema
    {
        private Lazy<Schema> schema;

        [BsonRequired]
        [BsonElement]
        public string Name { get; set; }

        [BsonRequired]
        [BsonElement]
        public string Label { get; set; }

        [BsonRequired]
        [BsonElement]
        public string Schema { get; set; }

        [BsonRequired]
        [BsonElement]
        public bool IsDeleted { get; set; }

        [BsonRequired]
        [BsonElement]
        public Guid AppId { get; set; }

        [BsonRequired]
        [BsonElement]
        public RefToken CreatedBy { get; set; }

        [BsonRequired]
        [BsonElement]
        public RefToken LastModifiedBy { get; set; }

        [BsonRequired]
        [BsonElement]
        public bool IsPublished { get; set; }

        Schema ISchemaEntityWithSchema.Schema
        {
            get { return schema.Value; }
        }

        public Lazy<Schema> DeserializeSchema(SchemaJsonSerializer serializer)
        {
            schema = new Lazy<Schema>(() => Schema != null ? serializer.Deserialize(JObject.Parse(Schema)) : null);

            return schema;
        }
    }
}