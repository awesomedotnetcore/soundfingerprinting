namespace SoundFingerprinting
{
    using System;
    using System.Collections.Generic;

    using SoundFingerprinting.Configuration;
    using SoundFingerprinting.DAO;
    using SoundFingerprinting.DAO.Data;
    using SoundFingerprinting.Data;

    public interface IModelService
    {
        IModelReference Insert(TrackInfo trackInfo, IEnumerable<HashedFingerprint> hashedFingerprints);

        FingerprintsQueryResponse ReadSubFingerprints(IEnumerable<QueryHash> hashes, QueryConfiguration config);

        IList<TrackData> ReadAllTracks();

        IList<TrackData> ReadTrackByArtistAndTitleName(string artist, string title);

        TrackData ReadTrackByReference(IModelReference trackReference);

        TrackData ReadTrackByISRC(string isrc);

        List<TrackData> ReadTracksByReferences(IEnumerable<IModelReference> ids);

        int DeleteTrack(IModelReference trackReference);

        bool ContainsTrack(string isrc, string artist, string title);

        void InsertHashDataForTrack(IEnumerable<HashedFingerprint> hashes, IModelReference trackReference);

        IModelReference InsertTrack(TrackData track);
    }
}
