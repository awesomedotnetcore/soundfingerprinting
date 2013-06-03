﻿namespace Soundfingerprinting.Hashing
{
    using System;

    using Soundfingerprinting.Hashing.LSH;
    using Soundfingerprinting.Hashing.MinHash;
    using Soundfingerprinting.Infrastructure;

    public class CombinedHashingAlgorithm : ICombinedHashingAlgoritm
    {
        private readonly IMinHashService minHashService;

        private readonly ILSHService lshService;

        public CombinedHashingAlgorithm()
            : this(DependencyResolver.Current.Get<IMinHashService>(), DependencyResolver.Current.Get<ILSHService>())
        {
        }

        public CombinedHashingAlgorithm(
            IMinHashService minHashService, ILSHService lshService)
        {
            this.minHashService = minHashService;
            this.lshService = lshService;
        }

        public Tuple<byte[], long[]> Hash(bool[] fingerprint, int numberOfHashTables, int numberOfHashKeysPerTable)
        {
            byte[] subFingerprint = minHashService.Hash(fingerprint);
            return new Tuple<byte[], long[]>(subFingerprint, lshService.Hash(subFingerprint, numberOfHashTables, numberOfHashKeysPerTable));
        }
    }
}
