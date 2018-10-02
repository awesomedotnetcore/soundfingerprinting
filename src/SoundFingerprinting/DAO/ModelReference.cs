﻿namespace SoundFingerprinting.DAO
{
    using System;

    using ProtoBuf;

    [Serializable]
    [ProtoContract]
    public class ModelReference<T> : IModelReference<T>
    {
        public ModelReference(T id)
        {
            Id = id;
        }

        private ModelReference()
        {
            // left for protobuf
        }

        public static ModelReference<T> Null { get; } = new ModelReference<T>(default(T));

        [ProtoMember(1)]
        public T Id { get; }

        object IModelReference.Id
        {
            get
            {
                return Id;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ModelReference<T>))
            {
                return false;
            }

            return Id.Equals(((ModelReference<T>)obj).Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
